using FluentValidation;
using PasswordManager.DTO;

namespace PasswordManager.Helpers.Validators
{
	public class EditUserDTOValidator : AbstractValidator<EditUserDTO>
    {

        public EditUserDTOValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Please enter a FirstName");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Please enter a LastName");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Please enter an Email");
        }
    }
}
