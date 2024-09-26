using library.business.ViewModels.BookViewModels;

namespace library.business.ViewModels
{
    public class PaginationViewModel
    {
        public List<GetAllBooksViewModel> Books { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
