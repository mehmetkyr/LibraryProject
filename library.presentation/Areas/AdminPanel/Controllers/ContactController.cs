using library.business.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace library.presentation.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [Area("AdminPanel")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<IActionResult> Contact()
        {
            var model = await _contactService.GetAllMessagesAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteMessageByIdAsync(id);
            return RedirectToAction("Contact", "Contact");
        }
    }
}
