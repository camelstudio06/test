using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
