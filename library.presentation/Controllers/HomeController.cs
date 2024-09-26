using library.business.ViewModels.ContactViewModels;
using library.business.Services.BookServices;
using library.business.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace library.presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IContactService _contactService;

        public HomeController(IBookService bookService, IContactService contactService)
        {
            _bookService = bookService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(string searchString, string categoryString, int page = 1)
        {
            var books = await _bookService.GetAllBooksWithPaginationAsync(searchString, categoryString, page);
            return View(books);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _contactService.CreateContactMessageAsync(model);
            ViewBag.Success = "Mesajýnýz gönderilmiþtir. En kýsa sürede mail adresinize dönüþ yapýlacaktýr.";
            return View();
        }
    }
}
