using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;

namespace ResumeProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultTestimonialComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
