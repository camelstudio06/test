using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turbo.Data;
using Turbo.Models;

namespace Turbo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly TurboDb _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<CustomUser> _userManager;

        public NewsController(TurboDb context,
                              IHostingEnvironment env,
                              UserManager<CustomUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Posts()
        {
            return View(_context.NewsPosts.Include(news => news.CustomUser));
        }
        public IActionResult PostsItem(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            NewsPost newsPostFromDb = _context.NewsPosts.Include(news => news.CustomUser)
                                                        .FirstOrDefault(news => news.Id == id);

            if(newsPostFromDb == null)
            {
                return NotFound();
            }

            return View(newsPostFromDb);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsPost newsPost)
        {
            if (!ModelState.IsValid)
            {
                return View(newsPost);
            }

            if (newsPost.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil yükləyin");
                return View(newsPost);
            }

            if (newsPost.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + newsPost.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newsPost.Photo.CopyToAsync(fileStream);
                }

                CustomUser customUserFromDb = await _userManager.FindByNameAsync(User.Identity.Name);

                NewsPost newNewsPost = new NewsPost()
                {
                    PhotoURL = fileName,
                    Title = newsPost.Title,
                    ShortInfo = newsPost.ShortInfo,
                    MainArticle = newsPost.MainArticle,
                    PublishDate = DateTime.Now,
                    CustomUserId = customUserFromDb.Id
                };

                _context.NewsPosts.Add(newNewsPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Posts", "News");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsPost newsPostFromDb = _context.NewsPosts.Find(id);

            if (newsPostFromDb == null)
            {
                return NotFound();
            }

            return View(newsPostFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, NewsPost newsPost)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsPost newsPostFromDb = _context.NewsPosts.Find(id);

            if (newsPostFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(newsPost);
            }

            if (newsPost.Photo != null)
            {
                if (newsPost.Photo.ContentType.Contains("image/"))
                {
                    string folderPath = Path.Combine(_env.WebRootPath, "img");
                    string fileName = Guid.NewGuid().ToString() + "_" + newsPost.Photo.FileName;
                    string filePath = Path.Combine(folderPath, fileName);
                    //string result = filePath.Replace(@"\", @"/");

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await newsPost.Photo.CopyToAsync(fileStream);
                    }

                    string currentFilePath = Path.Combine(_env.WebRootPath, "img", newsPostFromDb.PhotoURL);
                    if (System.IO.File.Exists(currentFilePath))
                    {
                        System.IO.File.Delete(currentFilePath);
                    }

                    newsPostFromDb.PhotoURL = fileName;
                }
            }

            newsPostFromDb.Title = newsPost.Title;
            newsPostFromDb.ShortInfo = newsPost.ShortInfo;
            newsPostFromDb.MainArticle = newsPost.MainArticle;

            await _context.SaveChangesAsync();

            return RedirectToAction("Posts", "News");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult DeleteGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsPost newsPostFromDb = _context.NewsPosts.Find(id);

            if (newsPostFromDb == null)
            {
                return NotFound();
            }

            return View(newsPostFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsPost newsPostFromDb = _context.NewsPosts.Find(id);

            if (newsPostFromDb == null)
            {
                return NotFound();
            }

            string currentFilePath = Path.Combine(_env.WebRootPath, "img", newsPostFromDb.PhotoURL);
            if (System.IO.File.Exists(currentFilePath))
            {
                System.IO.File.Delete(currentFilePath);
            }

            _context.NewsPosts.Remove(newsPostFromDb);
            await _context.SaveChangesAsync();

            return RedirectToAction("Posts", "News");
        }
    }
}