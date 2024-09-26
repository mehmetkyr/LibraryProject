using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using library.business.Services.BookServices;
using library.business.ViewModels.BookViewModels;

namespace library.presentation.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [Area("AdminPanel")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var books = await _bookService.GetAllBooksWithPaginationAsync(searchString, null, page);
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _bookService.AddNewBookAsync(model);
            ViewBag.Success = "Kitap başarıyla eklenmiştir.";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GetBookByIdViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return View(value);
            }
            await _bookService.UpdateBookAsync(value);
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GetBookByIdViewModel value)
        {
            await _bookService.DeleteBookAsync(value.Id);
            return RedirectToAction("Index", "Book");
        }

        public async Task<IActionResult> Receive(int id)
        {
            await _bookService.ReceiveBookAsync(id);
            return RedirectToAction("Index", "Book");
        }
    }
}
