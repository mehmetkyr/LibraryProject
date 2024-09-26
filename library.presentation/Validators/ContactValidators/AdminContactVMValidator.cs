using FluentValidation;
using library.business.ViewModels.ContactViewModels;

namespace library.presentation.Validators.ContactValidators
{
    public class AdminContactVMValidator : AbstractValidator<AdminContactViewModel>
    {
        public AdminContactVMValidator()
        {

        }
    }
}
