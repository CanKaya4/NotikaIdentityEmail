using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NotikaIdentityEmail.Entities;
using NotikaIdentityEmail.Models;

namespace NotikaIdentityEmail.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterUserViewModel registerUserViewModel)
        {
            Random rnd = new Random();
            int code = rnd.Next(100000, 1000000);
            AppUser appUser = new AppUser()
            {
                Name = registerUserViewModel.Name,
                Email = registerUserViewModel.Email,
                Surname = registerUserViewModel.Surname,
                UserName = registerUserViewModel.UserName,
                ActivationCode = code,
            };
            var result = await _userManager.CreateAsync(appUser, registerUserViewModel.Password);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "alikaya4275@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress malBoxAddressTo = new MailboxAddress("User", registerUserViewModel.Email);
                mimeMessage.To.Add(malBoxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Hesabınızı doğrulamak için geçerli olan doğrulama kodu " + code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Notika Identity Aktivasyon Kodu";
                
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587,false);
                smtpClient.Authenticate("alikaya4275@gmail.com", "maod kvce gblr wnib");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);

                return RedirectToAction("UserActivation", "Activation");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
