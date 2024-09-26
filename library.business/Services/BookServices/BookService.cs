using AutoMapper;
using library.data.Models;
using library.data.Repositories;
using library.business.ViewModels;
using library.business.ViewModels.BookViewModels;

namespace library.business.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewBookAsync(AddBookViewModel value)
        {
            var book = _mapper.Map<Book>(value);
            await _unitOfWork.BookRepo.CreateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _unitOfWork.BookRepo.GetByIdAsync(id);
            if (book != null)
            {
                await _unitOfWork.BookRepo.DeleteAsync(book);
            }
        }

        public async Task UpdateBookAsync(GetBookByIdViewModel value)
        {
            if (value != null)
            {
                var book = _mapper.Map<Book>(value);
                await _unitOfWork.BookRepo.UpdateAsync(book);
            }
        }

        public async Task<List<GetAllBooksViewModel>> GetAllBooksAsync(string searchString, string categoryString)
        {
            var books = await _unitOfWork.BookRepo.GetAllBooksWithMembersAsync();
            var bookVM = _mapper.Map<List<GetAllBooksViewModel>>(books);

            if (!string.IsNullOrEmpty(searchString))
            {
                bookVM = await GetBookByNameAsync(searchString);
            }
            if (!string.IsNullOrEmpty(categoryString))
            {
                bookVM = await GetBookByCategoryAsync(categoryString);
            }

            return bookVM;
        }

        public async Task<PaginationViewModel> GetAllBooksWithPaginationAsync(string searchString, string categoryString, int page)
        {
            if (string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(categoryString))
            {
                int pageSize = 10;
                int totalBooks = await _unitOfWork.BookRepo.CountAsync();
                int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalBooks) / Convert.ToDouble(pageSize)));

                var books = await _unitOfWork.BookRepo.GetAllBooksMemberWithPaginationAsync(pageSize, page);
                var booksVM = _mapper.Map<List<GetAllBooksViewModel>>(books);

                var viewModel = new PaginationViewModel
                {
                    Books = booksVM,
                    CurrentPage = page,
                    TotalPages = totalPages,
                };
                return viewModel;
            }
            else
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var books = await GetBookByNameAsync(searchString);
                    var viewModel = new PaginationViewModel { Books = books, TotalPages = 0 };
                    return viewModel;
                }
                else
                {
                    var books = await GetBookByCategoryAsync(categoryString);
                    var viewModel = new PaginationViewModel { Books = books, TotalPages = 0 };
                    return viewModel;
                }
            }
        }

        public async Task<List<GetAllBooksViewModel>> GetBookByCategoryAsync(string categoryName)
        {
            var books = await _unitOfWork.BookRepo.GetBookByCategoryAsync(categoryName);
            var bookVM = _mapper.Map<List<GetAllBooksViewModel>>(books);
            return bookVM;
        }

        public async Task<GetBookByIdViewModel> GetBookByIdAsync(int id)
        {
            var book = await _unitOfWork.BookRepo.GetByIdAsync(id);
            var bookVM = _mapper.Map<GetBookByIdViewModel>(book);
            return bookVM;
        }

        public async Task<List<GetAllBooksViewModel>> GetBookByNameAsync(string name)
        {
            var books = await _unitOfWork.BookRepo.GetBookByNameAsync(name);
            var bookVM = _mapper.Map<List<GetAllBooksViewModel>>(books);
            return bookVM;
        }

        public async Task ReceiveBookAsync(int id)
        {
            var book = await _unitOfWork.BookRepo.GetByIdAsync(id);

            if (book != null)
            {
                book.MemberId = null;
                book.Status = "On the shelf";
                book.BorrowedDate = null;

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
