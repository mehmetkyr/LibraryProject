using library.business.ViewModels.RoleViewModels;
using library.business.Services.MemberServices;
using library.data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace library.PresentationLayer.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public MemberController(IMemberService memberService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _memberService = memberService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchString, string message)
        {
            ViewBag.Message = message;

            var users = await _memberService.GetAllMembersWithRolesAsync(searchString);
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id, string message)
        {
            ViewBag.Message = message;

            var users = await _memberService.GetAllMembersWithRolesAsync(null);
            var user = users.FirstOrDefault(x => x.User.Id == id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", "Member", new { message = "Lütfen bir rol seçiniz." });
            }

            List<string> viewList = await _memberService.EditUserRoleAsync(model);
            return RedirectToAction("Edit", "Member", new { id = viewList[0], message = viewList[1] });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var control = await _memberService.DeleteMemberAsync(id);
            if (!control)
            {
                return RedirectToAction("Index", "Member", new { message = "Silmek istediğiniz kullanıcının ödünç almış olduğu kitaplar var. Bu nedenle kullanıcı sistemden silinemiyor." });
            }

            return RedirectToAction("Index", "Member");
        }
    }
}
