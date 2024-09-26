using library.data.Identity;

namespace library.business.ViewModels.BookViewModels
{
    public class MemberBookViewModel
    {
        public GetBookByIdViewModel Book { get; set; }
        public List<AppUser> Members { get; set; }
    }
}
