using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;
using System.Security.Claims;

namespace ResumeProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ResumeContext _context;

        public AuthController(ResumeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Auth auth)
        {
            var value = _context.Auths.FirstOrDefault(x => x.Email == auth.Email && x.Password == auth.Password);
            if (value != null)
            {
                //Session oluşturma
                HttpContext.Session.SetInt32("AdminId", value.AuthId);
                HttpContext.Session.SetString("AdminEmail", value.Email);

                //Authentication
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, value.Email),
                    new Claim(ClaimTypes.NameIdentifier, value.AuthId.ToString())
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                //expiration time
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2) //2 saat sonra logout
                };

                await HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Index", "About");
            }
            ViewBag.Error = "E-posta veya şifre hatalı";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Auth auth)
        {
            _context.Auths.Add(auth);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("CookieAuth");

            return RedirectToAction("Login", "Auth");
        }
    }
}
