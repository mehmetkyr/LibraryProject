using library.data.Data;
using library.data.Repositories.BookRepository;
using library.data.Repositories.ContactRepository;

namespace library.data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private readonly IBookRepository _bookRepo;
        private readonly IContactRepository _contactRepo;
        public UnitOfWork(Context context, IBookRepository bookRepo, IContactRepository contactRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
            _contactRepo = contactRepo;
        }

        public IContactRepository ContactRepo => _contactRepo;
        public IBookRepository BookRepo => _bookRepo;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
