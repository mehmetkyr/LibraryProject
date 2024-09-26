using AutoMapper;
using library.business.Services.BookServices;
using library.business.Services.MemberServices;
using library.data.Data;
using library.data.Repositories;
using library.business.ViewModels.BookViewModels;

namespace library.business.Services.LendServices
{
    public class LendService : ILendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public LendService(IBookService bookService, IMemberService memberService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookService = bookService;
            _memberService = memberService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<MemberBookViewModel> GetAllItemsForLendingAsync(string searchString, int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            var members = await _memberService.GetAllMembersAsync(searchString);

            MemberBookViewModel memberBook = new MemberBookViewModel
            {
                Book = book,
                Members = members
            };

            if (!string.IsNullOrEmpty(searchString))
            {
                memberBook.Members = memberBook.Members
                    .Where(x => x.FirstName.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }

            return memberBook;
        }

        public async Task LendBookAsync(int id, string memberId)
        {
            var member = await _memberService.GetMemberByIdAsync(memberId);
            var book = await _unitOfWork.BookRepo.GetByIdAsync(id);

            if (book != null && member != null)
            {
                book.MemberId = member.Id;
                book.Status = "Borrowed";
                book.BorrowedDate = DateTime.Now;

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
