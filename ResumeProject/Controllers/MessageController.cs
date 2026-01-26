using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Context;
using ResumeProject.Entities;

namespace ResumeProject.Controllers
{
    
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            ViewBag.ActiveMenu = "Messages";
            var values = _context.Messages.ToList();
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = _context.Messages.Find(id);
            message.IsRead = true;
            _context.SaveChanges();
            return View(message);
        } 

        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            var about = _context.Abouts.FirstOrDefault();
            var contact = _context.Contacts.FirstOrDefault();
            message.SenderEmail = contact.Email;
            message.SendDate = DateTime.Now;
            message.NameSurname = about.NameSurname;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult SendMessageToAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessageToAdmin(Message message)
        {
            var contact = _context.Contacts.FirstOrDefault();
            message.ReceiverEmail = contact.Email;
            message.SendDate = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}
