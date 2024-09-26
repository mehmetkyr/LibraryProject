using library.data.Data;
using library.data.Models;
using library.data.Repositories.GenericRepository;

namespace library.data.Repositories.ContactRepository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly Context _context;
        public ContactRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
