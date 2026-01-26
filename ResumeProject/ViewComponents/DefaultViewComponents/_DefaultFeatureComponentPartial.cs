using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;

namespace ResumeProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultFeatureComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.FirstOrDefault();
            return View(value);
        }
    }
}
