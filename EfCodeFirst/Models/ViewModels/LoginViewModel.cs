using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EfCodeFirst.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username bos ola bilmez")]
        [StringLength(50)]
        [Remote("CheckUsername", "Login",  ErrorMessage = "User Yoxdur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password bos ola bilmez")]
        [StringLength(50)]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}
