using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), StringLength(255, ErrorMessage = "Yazının uzunluğu 255 simvoldan uzun ola bilməz")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), EmailAddress(ErrorMessage = "Zəhmət olmasa, düzgün email daxil edin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa, boşluğu doldur"), DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
