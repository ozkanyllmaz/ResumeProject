using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly ResumeContext _context;

        public PortfolioController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult PortfolioList()
        {
            ViewBag.ActiveMenu = "Portfolio";
            var values = _context.Portfolios
                .Include(x => x.Category)
                .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);

            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name", value.CategoryId);

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name", portfolio.CategoryId);

            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
