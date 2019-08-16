using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
