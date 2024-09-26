using AutoMapper;
using library.data.Identity;
using library.data.Models;
using library.business.ViewModels.AppUserViewModels;
using library.business.ViewModels.BookViewModels;
using library.business.ViewModels.ContactViewModels;

namespace library.business.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, GetAllBooksViewModel>().ReverseMap();
            CreateMap<Book, GetBookByIdViewModel>().ReverseMap();
            CreateMap<Book, AddBookViewModel>().ReverseMap();

            CreateMap<Contact, ContactViewModel>().ReverseMap();
            CreateMap<Contact, AdminContactViewModel>().ReverseMap();

            CreateMap<AppUser, RegisterViewModel>().ReverseMap();
        }
    }
}
