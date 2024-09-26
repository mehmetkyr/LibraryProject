using System.ComponentModel.DataAnnotations;

namespace library.business.ViewModels.AppUserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
