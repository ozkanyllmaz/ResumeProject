using Microsoft.AspNetCore.Mvc;

namespace ResumeProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
