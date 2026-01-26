using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultMessageComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultMessageComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(new Message());
        }
    }
}
