using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ResumeContext _context;

        public ServiceController(ResumeContext context)
        {
            _context = context;
        }


        public IActionResult ServiceList()
        {
            ViewBag.ActiveMenu = "Services";
            var services = _context.Services.ToList();
            return View(services);
        }

        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = _context.Services.Find(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

    }
}
