using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ResumeContext _context;

        public SettingsController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult SettingsIndex()
        {
            ViewBag.ActiveMenu = "Settings";
            var auth = _context.Auths.FirstOrDefault(); 
            if(auth == null)
            {
                auth = new Auth();
            }

            return View(auth);
        }

        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePassword(Auth auth)
        {
            var user = _context.Auths.FirstOrDefault(x=>x.AuthId == auth.AuthId);
            if (user == null)
            {
                return NotFound();
            } 
            user.Password = auth.Password;
            _context.SaveChanges();
            return RedirectToAction("SettingsIndex");
        }
    }
}
