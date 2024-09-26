using AutoMapper;
using library.data.Data;
using library.data.Models;
using library.data.Repositories;
using library.business.ViewModels.ContactViewModels;
using Microsoft.EntityFrameworkCore;

namespace library.business.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateContactMessageAsync(ContactViewModel model)
        {
            var message = _mapper.Map<Contact>(model);
            await _unitOfWork.ContactRepo.CreateAsync(message);
        }

        public async Task DeleteMessageByIdAsync(int id)
        {
            var message = await _unitOfWork.ContactRepo.GetByIdAsync(id);
            await _unitOfWork.ContactRepo.DeleteAsync(message);
        }

        public async Task<List<AdminContactViewModel>> GetAllMessagesAsync()
        {
            var model = await _unitOfWork.ContactRepo.GetAllAsync();
            var modelDTO = _mapper.Map<List<AdminContactViewModel>>(model);
            return modelDTO;
        }
    }
}
