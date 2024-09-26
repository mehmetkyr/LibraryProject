using System.ComponentModel.DataAnnotations;

namespace library.business.ViewModels.AppUserViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MaxLength(20, ErrorMessage = "Bu alan en fazla 20 karakter içerebilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MaxLength(20, ErrorMessage = "Bu alan en fazla 20 karakter içerebilir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MaxLength(20, ErrorMessage = "Bu alan en fazla 20 karakter içerebilir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Bu alan en fazla 20 karakter içerebilir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolanız uyuşmuyor.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 karakter içerebilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MaxLength(200, ErrorMessage = "Bu alan en fazla 200 karakter içerebilir.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MaxLength(10, ErrorMessage = "Bu alan en fazla 10 karakter içerebilir.")]
        public string PhoneNumber { get; set; }
    }
}
