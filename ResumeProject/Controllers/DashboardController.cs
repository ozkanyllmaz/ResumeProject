using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProject.Context;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ResumeContext _context;

        public DashboardController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult DashboardList()
        {
            var model = new DashboardViewModel();

            //istatistikler
            model.TotalMessageCount = _context.Messages.Count();
            model.TotalProjectCount = _context.Portfolios.Count();  
            model.TotalExperienceCount = _context.Experiences.Count();
            model.TotalServiceCount = _context.Services.Count();

            //Hakkımda bilgileri
            model.AboutInfo = _context.Abouts.FirstOrDefault();

            //son 3 mesaj
            model.lastMessages = _context.Messages
                .OrderByDescending(x=>x.SendDate)
                .Take(3)
                .ToList();

            //son 3 proje
            model.lastPortfolio = _context.Portfolios
                .Include(x=>x.Category)
                .OrderByDescending(x=>x.PortfolioId)
                .Take(3)
                .ToList();

            return View(model);
        }
    }
}
