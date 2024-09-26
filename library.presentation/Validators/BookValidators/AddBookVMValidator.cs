using FluentValidation;
using library.business.ViewModels.BookViewModels;

namespace library.presentation.Validators.BookValidators
{
    public class AddBookVMValidator : AbstractValidator<AddBookViewModel>
    {
        public AddBookVMValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(100).WithMessage("Name alanı en fazla 100 karakter içerebilir.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(100).WithMessage("Image alanı en fazla 100 karakter içerebilir.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .Must(isbn => isbn.ToString().Length == 13).WithMessage("ISBN alanı 13 karakter içermelidir.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(50).WithMessage("Author alanı en fazla 50 karakter içerebilir.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(30).WithMessage("Type alanı en fazla 30 karakter içerebilir.");

            RuleFor(x => x.LocationInfo)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.")
                .MaximumLength(10).WithMessage("Location Info alanı en fazla 10 karakter içerebilir.");

            RuleFor(x => x.PublishDateTime)
                .NotEmpty().WithMessage("Bu alanın doldurulması zorunludur.");
        }
    }
}
