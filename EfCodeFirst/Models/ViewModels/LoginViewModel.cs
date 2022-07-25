using System.ComponentModel.DataAnnotations;

namespace EfCodeFirst.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username bos ola bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password bos ola bilmez")]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}
