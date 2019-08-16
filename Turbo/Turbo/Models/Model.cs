using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class Model
    {
        public Model()
        {
            Automobiles = new HashSet<Automobile>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "9Zəhmət olmasa, boşluğu doldur")]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Automobile> Automobiles { get; set; }
    }
}
