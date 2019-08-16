using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class Automobile
    {
        public Automobile()
        {
            AutoPhotos = new HashSet<AutoPhoto>();
            Announcements = new HashSet<Announcement>();
        }
        public int Id { get; set; }
        public string MainPhotoURL { get; set; }
        [Required(ErrorMessage = "1Zəhmət olmasa, boşluğu doldur")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "2Zəhmət olmasa, boşluğu doldur")]
        public int? ModelId { get; set; }
        public virtual Model Model { get; set; }
        public DateTime Year { get; set; }
        [Required(ErrorMessage = "3Zəhmət olmasa, boşluğu doldur")]
        public int? Motor { get; set; }
        public int Distance { get; set; }
        [Required(ErrorMessage = "4Zəhmət olmasa, boşluğu doldur")]
        public int? ColorId { get; set; }
        public virtual Color Color { get; set; }
        [Required(ErrorMessage = "5Zəhmət olmasa, boşluğu doldur")]
        public int? FuelId { get; set; }
        public virtual Fuel Fuel { get; set; }
        [Required(ErrorMessage = "6Zəhmət olmasa, boşluğu doldur")]
        public int? SpeedControlId { get; set; }
        public virtual SpeedControl SpeedControl { get; set; }
        public virtual ICollection<AutoPhoto> AutoPhotos { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        [Required(ErrorMessage = "7Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string ShortInfo { get; set; }
        [StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string FullInfo { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
