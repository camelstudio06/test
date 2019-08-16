using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turbo.Data;
using Turbo.Models;
using Turbo.ViewModels;

namespace Turbo.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly TurboDb _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<CustomUser> _userManager;
        private Automobile automobile;

        public AnnouncementController(TurboDb context,
                                      IHostingEnvironment env,
                                      UserManager<CustomUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Lists()
        {
            IEnumerable<Announcement> allAnnouncements = _context.Announcements.Include(announce => announce.Automobile)
                                                                               .ThenInclude(announce => announce.Model)
                                                                               .ThenInclude(announce => announce.Brand)
                                                                               .Include(announce => announce.Location);
            return View(allAnnouncements);
        }
        public IActionResult VIP()
        {
            HomeVM homeVM = new HomeVM
            {
                VIPAnnouncements = _context.Announcements.Where(announce => announce.IsVIP == true)
                                                         .Include(announce => announce.Automobile)
                                                         .ThenInclude(announce => announce.Model)
                                                         .ThenInclude(announce => announce.Brand)
                                                         .Include(announce => announce.Location),
            };
            return View("VIPAnnouncementsPartialView", homeVM);
        }
        public IActionResult ListsItem(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Announcement announcementFromDb = _context.Announcements.Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.Model)
                                                                    .ThenInclude(announce => announce.Brand)
                                                                    .Include(announce => announce.Location)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.Color)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.Fuel)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.AutoPhotos)
                                                                    .FirstOrDefault(announce => announce.Id == id);
            if(announcementFromDb == null)
            {
                return NotFound();
            }

            ViewBag.AnnouncementsWithSameModels = _context.Announcements.Where(announce => announce.Automobile.ModelId == announcementFromDb.Automobile.ModelId);

            return View(announcementFromDb);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if(!User.IsInRole("İstifadəçi"))
            {
                TempData["Log in as an ordinary user"] = true;
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Brands = _context.Brands;
            ViewBag.Models = _context.Models;
            ViewBag.Colors = _context.Colors;
            ViewBag.Locations = _context.Locations;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.SpeedControls = _context.SpeedControls;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementVM announcementVM)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Brands = _context.Brands;
                ViewBag.Models = _context.Models;
                ViewBag.Colors = _context.Colors;
                ViewBag.Locations = _context.Locations;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.SpeedControls = _context.SpeedControls;
                return View(announcementVM);
            }

            if(announcementVM.Photo == null)
            {
                ViewBag.Brands = _context.Brands;
                ViewBag.Models = _context.Models;
                ViewBag.Colors = _context.Colors;
                ViewBag.Locations = _context.Locations;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.SpeedControls = _context.SpeedControls;
                ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil yükləyin");
                return View(announcementVM);
            }

            if(announcementVM.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + announcementVM.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);

                using(FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                   await announcementVM.Photo.CopyToAsync(fileStream);
                }

                automobile = new Automobile
                {
                    MainPhotoURL = fileName,
                    Price = announcementVM.Price,
                    ModelId = announcementVM.ModelId,
                    Year = announcementVM.Year,
                    Motor = announcementVM.Motor,
                    Distance = announcementVM.Distance,
                    ColorId = announcementVM.ColorId,
                    FuelId = announcementVM.FuelId,
                    SpeedControlId = announcementVM.SpeedControlId,
                    ShortInfo = announcementVM.ShortInfo
                };

                await _context.Automobiles.AddAsync(automobile);
                await _context.SaveChangesAsync();
            }


            if(announcementVM.Photos != null && announcementVM.Photos.Count() > 0)
            {
                foreach (IFormFile photo in announcementVM.Photos)
                {
                    if(photo.ContentType.Contains("image/"))
                    {
                        string folderPath = Path.Combine(_env.WebRootPath, "img");
                        string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(folderPath, fileName);

                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(fileStream);
                        }

                        AutoPhoto autoPhoto = new AutoPhoto
                        {
                            PhotoURL = fileName,
                            AutomobileId = automobile.Id
                        };

                        await _context.AutoPhotos.AddAsync(autoPhoto);
                        await _context.SaveChangesAsync();
                    }
                }
            }



            CustomUser customUserFromDb = await _userManager.FindByNameAsync(User.Identity.Name);

            Announcement announcement = new Announcement
            {

                AutomobileId = automobile.Id,
                PublishDate = DateTime.Now,
                LocationId = announcementVM.LocationId,
                CustomUserId = customUserFromDb.Id,
                IsVIP = announcementVM.IsVIP
            };

            await _context.Announcements.AddAsync(announcement);
            await _context.SaveChangesAsync();

            TempData["Announcement created"] = true;

            ViewBag.Brands = _context.Brands;
            ViewBag.Models = _context.Models;
            ViewBag.Colors = _context.Colors;
            ViewBag.Locations = _context.Locations;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.SpeedControls = _context.SpeedControls;

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> MyLists(string name)
        {
            if(name == null)
            {
                return NotFound();
            }
            CustomUser customUserFromDb = await _userManager.FindByNameAsync(name);
            if(customUserFromDb == null)
            {
                return NotFound();
            }
            IEnumerable<Announcement> announcements = _context.Announcements.Where(announce => announce.CustomUserId == customUserFromDb.Id)
                                                                            .Include(announce => announce.Automobile)
                                                                            .ThenInclude(announce => announce.Model)
                                                                            .ThenInclude(announce => announce.Brand)
                                                                            .Include(announce => announce.Location)
                                                                            .Include(announce => announce.Automobile)
                                                                            .ThenInclude(announce => announce.Color)
                                                                            .Include(announce => announce.Automobile)
                                                                            .ThenInclude(announce => announce.Fuel);

            return View(announcements);
        }

        [HttpGet]
        public IActionResult EditItem(int? id)
        {
            if (id == null)
            {
                ViewBag.Brands = _context.Brands;
                ViewBag.Models = _context.Models;
                ViewBag.Colors = _context.Colors;
                ViewBag.Locations = _context.Locations;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.SpeedControls = _context.SpeedControls;
                return NotFound();
            }
            //Announcement announcementFromDb = _context.Announcements.Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.Model)
            //                                                        .ThenInclude(announce => announce.Brand)
            //                                                        .Include(announce => announce.Location)
            //                                                        .Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.Color)
            //                                                        .Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.Fuel)
            //                                                        .Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.SpeedControl)
            //                                                        .FirstOrDefault(announce => announce.Id == id);

            Announcement announcementFromDb = _context.Announcements.FirstOrDefault(announce => announce.Id == id);

            if (announcementFromDb == null)
            {
                ViewBag.Brands = _context.Brands;
                ViewBag.Models = _context.Models;
                ViewBag.Colors = _context.Colors;
                ViewBag.Locations = _context.Locations;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.SpeedControls = _context.SpeedControls;
                return NotFound();
            }

            ViewBag.Brands = _context.Brands;
            ViewBag.Models = _context.Models;
            ViewBag.Colors = _context.Colors;
            ViewBag.Locations = _context.Locations;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.SpeedControls = _context.SpeedControls;

            return View(announcementFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditItem(int? id, Announcement announcement)
        {
            //Announcement announcementFromDb = _context.Announcements.Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.Model)
            //                                                        .ThenInclude(announce => announce.Brand)
            //                                                        .Include(announce => announce.Location)
            //                                                        .Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.Color)
            //                                                        .Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.Fuel)
            //                                                        .Include(announce => announce.Automobile)
            //                                                        .ThenInclude(announce => announce.SpeedControl)
            //                                                        .FirstOrDefault(announce => announce.Id == id);

            Announcement announcementFromDb = _context.Announcements.FirstOrDefault(announce => announce.Id == id);

            if (announcementFromDb == null)
            {
                ViewBag.Brands = _context.Brands;
                ViewBag.Models = _context.Models;
                ViewBag.Colors = _context.Colors;
                ViewBag.Locations = _context.Locations;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.SpeedControls = _context.SpeedControls;
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Brands = _context.Brands;
                ViewBag.Models = _context.Models;
                ViewBag.Colors = _context.Colors;
                ViewBag.Locations = _context.Locations;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.SpeedControls = _context.SpeedControls;
                return View(announcement);
            }

                if (announcement.Automobile.Photo != null)
                {
                    if (announcement.Automobile.Photo.ContentType.Contains("image/"))
                    {
                        string folderPath = Path.Combine(_env.WebRootPath, "img");
                        string fileName = Guid.NewGuid().ToString() + "_" + announcement.Automobile.Photo.FileName;
                        string filePath = Path.Combine(folderPath, fileName);

                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await announcement.Automobile.Photo.CopyToAsync(fileStream);
                        }

                        string currentFilePath = Path.Combine(_env.WebRootPath, "img", announcementFromDb.Automobile.MainPhotoURL);
                        if (System.IO.File.Exists(currentFilePath))
                        {
                            System.IO.File.Delete(currentFilePath);
                        }

                        announcementFromDb.Automobile.MainPhotoURL = fileName;
                        await _context.SaveChangesAsync();
                    }
                }

                announcementFromDb.Automobile.Price = announcement.Automobile.Price;
                announcementFromDb.Automobile.ModelId = announcement.Automobile.ModelId;
                announcementFromDb.Automobile.Year = announcement.Automobile.Year;
                announcementFromDb.Automobile.Motor = announcement.Automobile.Motor;
                announcementFromDb.Automobile.Distance = announcement.Automobile.Distance;
                announcementFromDb.Automobile.ColorId = announcement.Automobile.ColorId;
                announcementFromDb.Automobile.FuelId = announcement.Automobile.FuelId;
                announcementFromDb.Automobile.SpeedControlId = announcement.Automobile.SpeedControlId;
                announcementFromDb.Automobile.ShortInfo = announcement.Automobile.ShortInfo;
                await _context.SaveChangesAsync();


            if (announcement.Photos != null && announcement.Photos.Count() > 0)
            {
                foreach (IFormFile photo in announcement.Photos)
                {
                    if (photo.ContentType.Contains("image/"))
                    {
                        string folderPath = Path.Combine(_env.WebRootPath, "img");
                        string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(folderPath, fileName);

                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(fileStream);
                        }

                        foreach (var autoPhoto in announcementFromDb.Automobile.AutoPhotos)
                        {
                            string currentFilePath = Path.Combine(_env.WebRootPath, "img", autoPhoto.PhotoURL);
                            if (System.IO.File.Exists(currentFilePath))
                            {
                                System.IO.File.Delete(currentFilePath);
                            }

                            autoPhoto.PhotoURL = fileName;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }


            //if (announcement.Photos != null && announcement.Photos.Count() > 0)
            //{
            //    foreach (IFormFile photo in announcement.Photos)
            //    {
            //        if (photo.ContentType.Contains("image/"))
            //        {
            //            string folderPath = Path.Combine(_env.WebRootPath, "img");
            //            string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            //            string filePath = Path.Combine(folderPath, fileName);

            //            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            //            {
            //                await photo.CopyToAsync(fileStream);
            //            }

            //            //foreach (var autoPhoto in announcementFromDb.Automobile.AutoPhotos)
            //            //{
            //            //    string currentFilePath = Path.Combine(_env.WebRootPath, "img", autoPhoto.PhotoURL);
            //            //    if (System.IO.File.Exists(currentFilePath))
            //            //    {
            //            //        System.IO.File.Delete(currentFilePath);
            //            //    }

            //            //    _context.AutoPhotos.Remove(autoPhoto);
            //            //    await _context.SaveChangesAsync();
            //            //}

            //            AutoPhoto newAutoPhoto = new AutoPhoto
            //            {
            //                PhotoURL = fileName,
            //            };

            //            _context.AutoPhotos.Add(newAutoPhoto);
            //            await _context.SaveChangesAsync();
            //        }
            //    }
            //}



            announcementFromDb.UpdateDate = DateTime.Now;
                announcementFromDb.LocationId = announcement.LocationId;
                announcementFromDb.IsVIP = announcement.IsVIP;
                await _context.SaveChangesAsync();

            TempData["Announcement updated"] = true;

            ViewBag.Brands = _context.Brands;
            ViewBag.Models = _context.Models;
            ViewBag.Colors = _context.Colors;
            ViewBag.Locations = _context.Locations;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.SpeedControls = _context.SpeedControls;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DeleteItem(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Announcement announcementFromDb = _context.Announcements.Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.Model)
                                                                    .ThenInclude(announce => announce.Brand)
                                                                    .Include(announce => announce.Location)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.Color)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.Fuel)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.SpeedControl)
                                                                    .Include(announce => announce.Automobile)
                                                                    .ThenInclude(announce => announce.AutoPhotos)
                                                                    .FirstOrDefault(announce => announce.Id == id);
            if(announcementFromDb == null)
            {
                return NotFound();
            }
            return View(announcementFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(Announcement announcement)
        {
            if(announcement == null)
            {
                return NotFound();
            }

            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            TempData["Removing of Announcement"] = true;
            return RedirectToAction("Index", "Home");
        }

    }
}