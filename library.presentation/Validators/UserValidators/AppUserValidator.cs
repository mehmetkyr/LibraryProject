using FluentValidation;
using library.data.Identity;

namespace library.presentation.Validators.UserValidators
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(50).WithMessage("First Name alanı en fazla 50 karakter içerebilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(50).WithMessage("Last Name alanı en fazla 50 karakter içerebilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
                .MaximumLength(100).WithMessage("Email alanı en fazla 150 karakter içerebilir.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(200).WithMessage("Address alanı en fazla 200 karakter içerebilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .Must(pn => pn.ToString().Length == 10).WithMessage("Geçerli bir telefon numarası giriniz.");
        }
    }
}
