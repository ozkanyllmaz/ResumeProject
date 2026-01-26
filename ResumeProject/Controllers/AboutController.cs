using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis;
using Document = iTextSharp.text.Document;


namespace ResumeProject.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ActiveMenu = "About";
            var values = _context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            about.IsActive = false;
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);  
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult TakeActiveAbout(int id)
        {
            var activeAbouts = _context.Abouts.FirstOrDefault(x => x.IsActive);
            if(activeAbouts != null)
            {
                activeAbouts.IsActive = false;
            }

            var about = _context.Abouts.FirstOrDefault(x => x.AboutId == id);
            if (about == null)
                return NotFound();

            about.IsActive = true;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DownloadCV()
        {
            try
            {
                // Tüm verileri veritabanından çek
                var about = _context.Abouts.FirstOrDefault();
                var educations = _context.Educations.OrderByDescending(e => e.Date).ToList();
                var experiences = _context.Experiences.OrderByDescending(e => e.WorkDate).ToList();
                var skills = _context.Skills.OrderByDescending(s => s.Range).ToList();
                var services = _context.Services.ToList();
                var portfolios = _context.Portfolios.ToList();

                if (about == null)
                    return NotFound("Hakkında bilgisi bulunamadı");

                // PDF oluştur
                Document document = new Document(PageSize.A4);
                document.SetMargins(40, 40, 40, 40);

                MemoryStream ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                // Turkish karakterleri destekleyen font
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font titleFont = new Font(baseFont, 28, Font.BOLD);
                Font jobTitleFont = new Font(baseFont, 14, Font.ITALIC);
                Font sectionFont = new Font(baseFont, 12, Font.BOLD);
                Font boldFont = new Font(baseFont, 11, Font.BOLD);
                Font normalFont = new Font(baseFont, 10);
                Font smallFont = new Font(baseFont, 9);
                Font italicFont = new Font(baseFont, 9, Font.ITALIC);

                // 1. BAŞLIK VE KİŞİSEL BİLGİLER
                Paragraph nameTitle = new Paragraph(about.NameSurname, titleFont);
                nameTitle.Alignment = Element.ALIGN_CENTER;
                document.Add(nameTitle);

                Paragraph jobTitle = new Paragraph(about.Title, jobTitleFont);
                jobTitle.Alignment = Element.ALIGN_CENTER;
                document.Add(jobTitle);

                document.Add(new Paragraph(" "));

                // Çizgi
                document.Add(new Paragraph("_________________________________________________________"));
                document.Add(new Paragraph(" "));

                // 2. ÖZET (ABOUT)
                AddSection(document, "Özgeçmiş", sectionFont);
                document.Add(new Paragraph(about.Description, normalFont));
                document.Add(new Paragraph(" "));

                // 3. EĞİTİM
                if (educations.Count > 0)
                {
                    AddSection(document, "Eğitim", sectionFont);
                    foreach (var education in educations)
                    {
                        Paragraph eduTitle = new Paragraph(education.School, boldFont);
                        document.Add(eduTitle);

                        Paragraph eduSection = new Paragraph(education.Section + " | " + education.Date, italicFont);
                        document.Add(eduSection);
                        document.Add(new Paragraph(" "));
                    }
                }

                // 4. DENEYIM
                if (experiences.Count > 0)
                {
                    AddSection(document, "Deneyim", sectionFont);
                    foreach (var experience in experiences)
                    {
                        Paragraph expTitle = new Paragraph(experience.Title, boldFont);
                        document.Add(expTitle);

                        Paragraph expDate = new Paragraph(experience.WorkDate, italicFont);
                        document.Add(expDate);

                        Paragraph expDesc = new Paragraph(experience.Description, normalFont);
                        document.Add(expDesc);
                        document.Add(new Paragraph(" "));
                    }
                }

                // 5. UZMANLUK ALANLARI (SERVİSLER)
                if (services.Count > 0)
                {
                    AddSection(document, "Hizmetler", sectionFont);
                    foreach (var service in services)
                    {
                        Paragraph serviceTitle = new Paragraph(service.Title, boldFont);
                        document.Add(serviceTitle);

                        Paragraph serviceDesc = new Paragraph(service.Description, smallFont);
                        document.Add(serviceDesc);
                        document.Add(new Paragraph(" "));
                    }
                }

                // 6. YETENEKLER (SKİLLS)
                if (skills.Count > 0)
                {
                    AddSection(document, "Yetenekler", sectionFont);
                    PdfPTable skillsTable = new PdfPTable(2);
                    skillsTable.WidthPercentage = 100;

                    foreach (var skill in skills)
                    {
                        PdfPCell skillCell = new PdfPCell(new Phrase(skill.SkillName, normalFont));
                        skillCell.Border = 0;
                        skillsTable.AddCell(skillCell);

                        // Proficiency göstergesi
                        string proficiency = new string('█', skill.Range / 10) +
                                            new string('░', 10 - (skill.Range / 10));
                        PdfPCell profCell = new PdfPCell(new Phrase(proficiency + " " + skill.Range + "%", smallFont));
                        profCell.Border = 0;
                        skillsTable.AddCell(profCell);
                    }
                    document.Add(skillsTable);
                    document.Add(new Paragraph(" "));
                }

                // 7. PORTFÖY
                if (portfolios.Count > 0)
                {
                    AddSection(document, "Portföy", sectionFont);
                    Paragraph portfolioList = new Paragraph();
                    foreach (var portfolio in portfolios)
                    {
                        portfolioList.Add(new Chunk("• " + portfolio.Title + "\n", normalFont));
                    }
                    document.Add(portfolioList);
                }

                document.Close();

                byte[] pdfBytes = ms.ToArray();
                ms.Close();

                return File(pdfBytes, "application/pdf", $"{about.NameSurname}_CV.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest("PDF oluşturulamadı: " + ex.Message);
            }
        }

        // Yardımcı method - Section başlıkları
        private void AddSection(Document document, string sectionTitle, Font font)
        {
            Paragraph section = new Paragraph(sectionTitle, font);
            section.SpacingBefore = 10;
            section.SpacingAfter = 5;
            document.Add(section);

            // Alt çizgi
            document.Add(new Paragraph("_______________________________________________"));
            document.Add(new Paragraph(" "));
        }
    }
}
