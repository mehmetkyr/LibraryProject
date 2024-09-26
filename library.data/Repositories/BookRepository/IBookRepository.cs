using library.data.Models;
using library.data.Repositories.GenericRepository;

namespace library.data.Repositories.BookRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetAllBooksWithMembersAsync();
        Task<List<Book>> GetAllBooksMemberWithPaginationAsync(int pageSize, int page);
        Task<List<Book>> GetBookByCategoryAsync(string categoryName);
        Task<List<Book>> GetBookByNameAsync(string name);
        Task<Book> GetBookByMemberIdAsync(string id);
    }
}
