using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Turbo.Data;
using Turbo.Models;

namespace Turbo.Controllers
{
    public class AjaxController : Controller
    {
        private readonly TurboDb _context;
        public AjaxController(TurboDb context)
        {
            _context = context;
        }
        public IActionResult GetModels(int? brandId)
        {
            if(brandId == null)
            {
                return NotFound();
            }

            IEnumerable<Model> models = _context.Models.Where(model => model.BrandId == brandId);

            return PartialView("GetModelsPartialView", models);
        }
    }
}