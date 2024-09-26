using library.data.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace library.business.ViewModels.RoleViewModels
{
    public class UserRoleViewModel
    {
        public AppUser User { get; set; }
        public List<string> UserRoles { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        [Required]
        public string radioChecked { get; set; }
    }
}
