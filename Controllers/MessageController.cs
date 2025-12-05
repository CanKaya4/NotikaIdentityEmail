using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotikaIdentityEmail.Context;

namespace NotikaIdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;

        public MessageController(EmailContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Inbox()
        {
            var values = await _context.Messages.Include(x => x.Category).ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> Sendbox()
        {
            var values = await _context.Messages.Include(x=>x.Category).ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> MessageDetail()
        {
            var value = await _context.Messages.Where(x => x.MessageId == 1).FirstOrDefaultAsync();
            return View(value);
        }
        public async Task<IActionResult> ComposeMessage()
        {
            return View();
        }
    }
}
