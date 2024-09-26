using library.data.Repositories.BookRepository;
using library.data.Repositories.ContactRepository;

namespace library.data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepo { get; }
        IContactRepository ContactRepo { get; }
        Task SaveChangesAsync();
    }
}
