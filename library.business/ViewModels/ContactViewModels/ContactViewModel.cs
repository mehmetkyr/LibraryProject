using System.ComponentModel.DataAnnotations;

namespace library.business.ViewModels.ContactViewModels
{
    public class ContactViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(10, ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
