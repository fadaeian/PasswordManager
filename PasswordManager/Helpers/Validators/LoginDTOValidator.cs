using FluentValidation;
using PasswordManager.DTO;

namespace PasswordManager.Helpers.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {

        public LoginDTOValidator()
    {
        RuleFor(p => p.UserName).NotEmpty().WithMessage("Please enter a username");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Please enter a password");
    }
}
}
