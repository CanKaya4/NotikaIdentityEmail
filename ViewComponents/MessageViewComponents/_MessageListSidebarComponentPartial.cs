using Microsoft.AspNetCore.Mvc;
using NotikaIdentityEmail.Context;

namespace NotikaIdentityEmail.ViewComponents.MessageViewComponents
{
    public class _MessageListSidebarComponentPartial : ViewComponent
    {
        private readonly EmailContext _emailContext;
        public _MessageListSidebarComponentPartial(EmailContext emailContext)
        {
            _emailContext = emailContext;
        }
        public  IViewComponentResult Invoke()
        {
            var values = _emailContext.Categories.ToList();
            return View(values);
        }
    }
}
