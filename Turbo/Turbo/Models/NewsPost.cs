using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class NewsPost
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(500, ErrorMessage = "Yazının uzunluğu 500 simvoldan uzun ola bilməz")]
        public string ShortInfo { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(5000, ErrorMessage = "Yazının uzunluğu 5000 simvoldan uzun ola bilməz")]
        public string MainArticle { get; set; }
        public DateTime PublishDate { get; set; }
        public string CustomUserId { get; set; }
        public virtual CustomUser CustomUser { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
