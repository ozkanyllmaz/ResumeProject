using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;

namespace ResumeProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultContactComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Contacts.FirstOrDefault();
            return View(value);
        }
    }
}
