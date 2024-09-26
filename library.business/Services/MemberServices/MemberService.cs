using AutoMapper;
using library.data.Identity;
using library.data.Repositories;
using library.business.ViewModels.AppUserViewModels;
using library.business.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace library.business.Services.MemberServices
{
    public class MemberService : IMemberService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddMemberAsync(RegisterViewModel model)
        {
            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            bool control = result.Succeeded;

            //default user role
            var forDefaultRole = await _userManager.FindByEmailAsync(model.Email);
            await _userManager.AddToRoleAsync(forDefaultRole, "User");
            return control;
        }

        public async Task<List<string>> EditUserRoleAsync(UserRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.radioChecked);
            var user = await _userManager.FindByIdAsync(model.User.Id);
            var isInRoleCheck = await _userManager.IsInRoleAsync(user, role.Name);

            List<string> returnList = new List<string> { user.Id };
            string messageTemplate = "";

            if (!isInRoleCheck)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                messageTemplate = $"{user.UserName} takma adlı kullanıcı için {role.Name} rolü eklendi.";
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, role.Name);
                messageTemplate = $"{user.UserName} takma adlı kullanıcı için {role.Name} rolü silindi.";
            }
            returnList.Add(messageTemplate);

            return returnList;
        }

        public async Task<bool> DeleteMemberAsync(string id)
        {
            bool control = false;
            var member = await GetMemberByIdAsync(id);
            var book = await _unitOfWork.BookRepo.GetBookByMemberIdAsync(id);

            if (book == null)
            {
                control = true;
                await _userManager.DeleteAsync(member);
            }

            return control;
        }

        public async Task<List<AppUser>> GetAllMembersAsync(string searchString)
        {
            var members = await _userManager.Users.AsNoTracking().ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                members = members.Where(x => x.FirstName.ToLower().Contains(searchString.ToLower())).ToList();
            }

            return members;
        }

        public async Task<List<UserRoleViewModel>> GetAllMembersWithRolesAsync(string searchString)
        {
            var usersWithRoles = new List<UserRoleViewModel>();
            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);

                var userWithRoles = new UserRoleViewModel
                {
                    User = user,
                    UserRoles = role.ToList(),
                    AllRoles = _roleManager.Roles.ToList(),
                };

                usersWithRoles.Add(userWithRoles);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                usersWithRoles = usersWithRoles.Where(x => x.User.FirstName.ToLower().Contains(searchString.ToLower())).ToList();
            }

            return usersWithRoles;
        }

        public async Task<AppUser> GetMemberByIdAsync(string id)
        {
            var member = await _userManager.FindByIdAsync(id);
            return member;
        }
    }
}
