using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public int AutomobileId { get; set; }
        public virtual Automobile Automobile { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Required(ErrorMessage = "8Zəhmət olmasa, boşluğu doldur")]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
        public string CustomUserId { get; set; }
        public virtual CustomUser CustomUser { get; set; }
        public bool IsVIP { get; set; }
        [NotMapped]
        public ICollection<IFormFile> Photos { get; set; }
    }
}
