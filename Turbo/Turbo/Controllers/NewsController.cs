using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Turbo.Data;
using Turbo.Models;

namespace Turbo.Controllers
{
    public class NewsController : Controller
    {
        private readonly TurboDb _context;
        public NewsController(TurboDb context)
        {
            _context = context;
        }

        public IActionResult Posts()
        {
            return View(_context.NewsPosts);
        }

        public IActionResult PostsItem(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            NewsPost newsPostFromDb = _context.NewsPosts.Find(id);
            if(newsPostFromDb == null)
            {
                return NotFound();
            }

            return View(newsPostFromDb);
        }
    }
}