using library.data.Data;
using library.data.Models;
using library.data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace library.data.Repositories.BookRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly Context _context;
        public BookRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksMemberWithPaginationAsync(int pageSize, int page)
        {
            var books = await _context.Books
                .Include(x => x.Member)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return books;
        }

        public async Task<List<Book>> GetAllBooksWithMembersAsync()
        {
            var books = await _context.Books
                .Include(x => x.Member)
                .AsNoTracking()
                .ToListAsync();

            return books;
        }

        public async Task<List<Book>> GetBookByCategoryAsync(string categoryName)
        {
            var books = await _context.Books
                 .Where(x => x.Type.ToLower().Contains(categoryName.ToLower()))
                 .AsNoTracking()
                 .ToListAsync();

            return books;
        }

        public async Task<Book> GetBookByMemberIdAsync(string id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.MemberId == id);

            return book;
        }

        public async Task<List<Book>> GetBookByNameAsync(string name)
        {
            var books = await _context.Books
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return books;
        }
    }
}
