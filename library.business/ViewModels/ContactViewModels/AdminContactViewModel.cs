using System.ComponentModel.DataAnnotations;

namespace library.business.ViewModels.ContactViewModels
{
    public class AdminContactViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
