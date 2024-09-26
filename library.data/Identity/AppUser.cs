using library.data.Models;
using Microsoft.AspNetCore.Identity;

namespace library.data.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
