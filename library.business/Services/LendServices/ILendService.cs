using library.business.ViewModels.BookViewModels;

namespace library.business.Services.LendServices
{
    public interface ILendService
    {
        Task<MemberBookViewModel> GetAllItemsForLendingAsync(string searchString, int id);
        Task LendBookAsync(int id, string memberId);
    }
}
