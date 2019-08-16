using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Turbo.Data;
using Turbo.Models;
using Turbo.ViewModels;

namespace Turbo.Controllers
{
    public class AccountController : Controller
    {
        private readonly TurboDb _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        public AccountController(TurboDb context,
                                 IConfiguration configuration,
                                 UserManager<CustomUser> userManager,
                                 SignInManager<CustomUser> signInManager
                                ) 
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(registerVM);
            }

            CustomUser customUser = new CustomUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                UserName = registerVM.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(customUser, registerVM.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    error.Description = "Qeydiyyat zamanı xəta baş verdi";
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(customUser, "İstifadəçi");

            #region Sending Email Confirmation Message
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.UseDefaultCredentials = false;
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential(_configuration["ConnectionStrings:SmtpClientCredentialEmail"], _configuration["ConnectionStrings:SmtpClientCredentialPassword"]);

            MailMessage message = new MailMessage("camelstudio06@gmail.com", registerVM.Email);

            message.IsBodyHtml = true;
            message.Subject = "Hesabın təsdiqlənməsi";
            message.Body = $"<a href='https://localhost:44365/Account/Confirmation/?userId={customUser.Id}'>Hesabını təsdiqlə</a>";

            client.Send(message);
            #endregion

            TempData["Confirm"] = true;

            return View();
        }

        public async Task<IActionResult> Confirmation(string userId)
        {
            if(userId != null)
            {
                CustomUser customUser = await _userManager.FindByIdAsync(userId);
                if(customUser != null)
                {
                    customUser.EmailConfirmed = true;
                    await _context.SaveChangesAsync();
                    TempData["Succeed"] = true;
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }

            CustomUser customUser = await _userManager.FindByNameAsync(loginVM.UserName);

            if (customUser == null)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz istifadəçi adı və ya şifrə səhvdir.");
                return View(loginVM);
            }

            if(customUser.EmailConfirmed == false)
            {
                ModelState.AddModelError("", "Elektron ünvanınıza daxil olub hesabınızı təsdiqləyin.");
                return View(loginVM);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(customUser, loginVM.Password, false, false);

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz istifadəçi adı və ya şifrə səhvdir.");
                return View(loginVM);
            }

            return RedirectToAction("Create", "Announcement");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}