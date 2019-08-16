using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turbo.Data;
using Turbo.Models;
using Turbo.ViewModels;

namespace Turbo.Controllers
{
    public class HomeController : Controller
    {
        private readonly TurboDb _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public HomeController(TurboDb context,
                              UserManager<CustomUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
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

            ViewBag.Brands = _context.Brands;
            ViewBag.Locations = _context.Locations;
            ViewBag.Models = _context.Models;
            ViewBag.AnnouncementsCount = _context.Announcements.Count();

            HomeVM homeVM = new HomeVM
            {
                VIPAnnouncements = _context.Announcements.Where(announce => announce.IsVIP == true)
                                                         .Include(announce => announce.Automobile)
                                                         .ThenInclude(announce => announce.Model)
                                                         .ThenInclude(announce => announce.Brand)
                                                         .Include(announce => announce.Location),
                RecentAnnouncements = _context.Announcements.OrderByDescending(announce => announce.PublishDate)
                                                            .Include(announce => announce.Automobile)
            };
            return View(homeVM);
        }
    }
}