using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ResumeContext _context;

        public TestimonialController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        // pasiften aktif et
        public IActionResult ActiveteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            if(testimonial == null)
            {
                return NotFound();
            }
            testimonial.isConfirm = true;
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        //aktiften pasif et
        public IActionResult PassiveTestimonial(int id)
        {
            var testimonial = _context.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            if(testimonial == null)
            {
                return NotFound();
            }

            testimonial.isConfirm = false;
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}
