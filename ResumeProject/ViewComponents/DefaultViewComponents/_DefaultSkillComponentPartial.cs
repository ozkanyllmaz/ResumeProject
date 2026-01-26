using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Models;

namespace ResumeProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultSkillComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultSkillComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new SkillModelView();
            
            model.Skills = _context.Skills.ToList();
            model.SkillText = _context.SkillTexts.FirstOrDefault();

            return View(model);
        }
    }
}
