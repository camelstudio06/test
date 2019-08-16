using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class CustomUser : IdentityUser
    {
        public CustomUser()
        {
            Announcements = new HashSet<Announcement>();
            NewsPosts = new HashSet<NewsPost>();
        }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string FirstName { get; set; }
        [StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string LastName { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<NewsPost> NewsPosts { get; set; }
    }
}
