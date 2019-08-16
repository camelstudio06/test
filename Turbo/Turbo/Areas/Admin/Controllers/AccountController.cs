using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Turbo.Data;
using Turbo.Models;
using Turbo.ViewModels;

namespace Turbo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly TurboDb _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(TurboDb context,
                              UserManager<CustomUser> userManager,
                              SignInManager<CustomUser> signInManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            #region Creating Roles("Admin", "İstifadəçi") and main user("useradmin") while running app
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("İstifadəçi"))
            {
                await _roleManager.CreateAsync(new IdentityRole("İstifadəçi"));
            }

            CustomUser customUserFromDb = await _userManager.FindByNameAsync("useradmin");
            if (customUserFromDb == null)
            {
                CustomUser customUser = new CustomUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "useradmin",
                    Email = "camelstudio06@gmail.com",
                    EmailConfirmed = true
                };

                IdentityResult result = await _userManager.CreateAsync(customUser, "userAdmin1234@");

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        error.Description = "Xəta baş verdi";
                        ModelState.AddModelError("", error.Description);
                    }
                }

                await _userManager.AddToRoleAsync(customUser, "Admin");
            }
            #endregion

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            CustomUser customUser = await _userManager.FindByNameAsync(loginVM.UserName);

            if (customUser == null)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz istifadəçi adı və ya şifrə səhvdir.");
                return View(loginVM);
            }

            if (customUser.EmailConfirmed == false)
            {
                ModelState.AddModelError("", "Elektron ünvanınıza daxil olub hesabınızı təsdiqləyin.");
                return View(loginVM);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(customUser, loginVM.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz istifadəçi adı və ya şifrə səhvdir.");
                return View(loginVM);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}