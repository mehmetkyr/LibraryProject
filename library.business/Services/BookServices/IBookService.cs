using library.business.ViewModels;
using library.business.ViewModels.BookViewModels;

namespace library.business.Services.BookServices
{
    public interface IBookService
    {
        Task<List<GetAllBooksViewModel>> GetAllBooksAsync(string searchString, string categoryString);
        Task<PaginationViewModel> GetAllBooksWithPaginationAsync(string searchString, string categoryString, int page);
        Task<List<GetAllBooksViewModel>> GetBookByNameAsync(string name);
        Task<List<GetAllBooksViewModel>> GetBookByCategoryAsync(string categoryName);
        Task<GetBookByIdViewModel> GetBookByIdAsync(int id);
        Task AddNewBookAsync(AddBookViewModel value);
        Task UpdateBookAsync(GetBookByIdViewModel value);
        Task DeleteBookAsync(int id);
        Task ReceiveBookAsync(int id);
    }
}
