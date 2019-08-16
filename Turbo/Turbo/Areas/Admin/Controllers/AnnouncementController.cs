using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turbo.Data;
using Turbo.Models;

namespace Turbo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly TurboDb _context;
        public AnnouncementController(TurboDb context)
        {
            _context = context;
        }

        public IActionResult Lists()
        {
            IEnumerable<Announcement> allAnnouncements = _context.Announcements.Include(announce => announce.Automobile)
                                                                               .ThenInclude(announce => announce.Model)
                                                                               .ThenInclude(announce => announce.Brand)
                                                                               .Include(announce => announce.Location)
                                                                               .Include(announce => announce.CustomUser);
            return View(allAnnouncements);
        }
        public IActionResult ListsItem(int? id)
        {
            if (id == null)
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
                                                                    .Include(announce => announce.CustomUser)
                                                                    .FirstOrDefault(announce => announce.Id == id);
            if (announcementFromDb == null)
            {
                return NotFound();
            }

            return View(announcementFromDb);
        }
    }
}