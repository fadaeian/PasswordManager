using FluentValidation;
using PasswordManager.DTO;

namespace PasswordManager.Helpers.Validators
{
    public class CreateUserDTOValidator: AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
    {
        RuleFor(p => p.UserName).NotEmpty().WithMessage("Please enter an username");
        RuleFor(p => p.Email).NotEmpty().WithMessage("Please enter an email");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Email is not in valid format");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Please enter a password");
        RuleFor(p => p.ConfirmPassword).NotEmpty().WithMessage("Please enter a password");
        RuleFor(p => p.ConfirmPassword).Equal(p => p.Password).WithMessage("Passwords are not matched");
        RuleFor(p => p.FirstName).NotEmpty().WithMessage("Please enter a firstname");
        RuleFor(p => p.LastName).NotEmpty().WithMessage("Please enter a lastname");
        RuleFor(p => p.RegisterDate).NotEmpty().WithMessage("Please enter a registerdate");
    }
    }
}
