using library.business.ViewModels.ContactViewModels;

namespace library.business.Services.ContactServices
{
    public interface IContactService
    {
        Task CreateContactMessageAsync(ContactViewModel model);
        Task<List<AdminContactViewModel>> GetAllMessagesAsync();
        Task DeleteMessageByIdAsync(int id);
    }
}
