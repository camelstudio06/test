using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.ViewModels
{
    public class AnnouncementVM
    {
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? BrandId { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? ModelId { get; set; }
        public int Distance { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? ColorId { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? LocationId { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? FuelId { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? SpeedControlId { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public DateTime Year { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public int? Motor { get; set; }
        public bool IsVIP { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string ShortInfo { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [NotMapped]
        public ICollection<IFormFile> Photos { get; set; }
    }
}
