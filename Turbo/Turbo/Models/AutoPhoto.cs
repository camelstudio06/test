using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Models
{
    public class AutoPhoto
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public int AutomobileId { get; set; }
        public virtual Automobile Automobile { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
