using Microsoft.AspNetCore.Identity;

namespace library.business.ViewModels.RoleViewModels
{
    public class RoleViewModel
    {
        public IdentityRole IdentityRole { get; set; }
        public List<IdentityRole> IListIdentityRole { get; set; }
    }
}
