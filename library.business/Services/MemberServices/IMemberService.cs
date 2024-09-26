using library.data.Identity;
using library.business.ViewModels.AppUserViewModels;
using library.business.ViewModels.RoleViewModels;

namespace library.business.Services.MemberServices
{
    public interface IMemberService
    {
        Task<List<UserRoleViewModel>> GetAllMembersWithRolesAsync(string searchString);
        Task<List<AppUser>> GetAllMembersAsync(string searchString);
        Task<AppUser> GetMemberByIdAsync(string id);
        Task<bool> DeleteMemberAsync(string id);
        Task<bool> AddMemberAsync(RegisterViewModel model);
        Task<List<string>> EditUserRoleAsync(UserRoleViewModel model);
    }
}
