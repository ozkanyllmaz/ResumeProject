using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Models;

namespace ResumeProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultAboutComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new AboutViewModel();

            //about
            model.Abouts = _context.Abouts.ToList();

            //Experience
            model.Experiences = _context.Experiences.ToList();

            //Education
            model.Educations = _context.Educations.ToList();

            return View(model);
        }
    }
}
