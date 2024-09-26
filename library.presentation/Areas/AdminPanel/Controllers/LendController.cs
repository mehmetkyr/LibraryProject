using library.business.Services.LendServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace library.PresentationLayer.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [Area("AdminPanel")]
    public class LendController : Controller
    {
        private readonly ILendService _lendService;

        public LendController(ILendService lendService)
        {
            _lendService = lendService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id, string searchString)
        {

            var memberBook = await _lendService.GetAllItemsForLendingAsync(searchString, id);
            return View(memberBook);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string memberId, int id)
        {
            await _lendService.LendBookAsync(id, memberId);
            return RedirectToAction("Index", "Book");
        }

    }
}
