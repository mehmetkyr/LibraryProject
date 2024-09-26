using FluentValidation;
using library.business.ViewModels.ContactViewModels;

namespace library.presentation.Validators.ContactValidators
{
    public class ContactVMValidator : AbstractValidator<ContactViewModel>
    {
        public ContactVMValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(30).WithMessage("Bu alan en fazla 30 karakter içerebilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(30).WithMessage("Bu alan en fazla 30 karakter içerebilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
                .MaximumLength(60).WithMessage("Bu alan en fazla 60 karakter içerebilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(100).WithMessage("Bu alan en fazla 100 karakter içerebilir.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(500).WithMessage("Bu alan en fazla 500 karakter içerebilir.");
        }
    }
}
