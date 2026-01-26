using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        private readonly ResumeContext _context;

        public SkillsController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            ViewBag.ActiveMenu = "Skills";
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkills()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkills(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult UpdateSkills(int id)
        {
            var value = _context.Skills.Find(id);
            return View(value);
        }

        [HttpPost]  
        public IActionResult UpdateSkills(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public IActionResult DeleteSkills(int id)
        {
            var value = _context.Skills.Find(id);
            _context.Skills.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }


    }

}
