using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;

namespace ResumeProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ResumeContext _context;

        public AdminController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
