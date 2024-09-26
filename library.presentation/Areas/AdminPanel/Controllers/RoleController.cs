using library.business.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.PresentationLayer.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _roleManager.Roles.AsNoTracking().ToListAsync();

            RoleViewModel roleViewModel = new RoleViewModel()
            {
                IListIdentityRole = model,
            };
            return View(roleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            var role = new IdentityRole()
            {
                Name = model.IdentityRole.Name,
            };

            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index", "Role");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index", "Role");
        }
    }
}
