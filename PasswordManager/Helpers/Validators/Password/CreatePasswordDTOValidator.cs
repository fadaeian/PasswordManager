using FluentValidation;
using PasswordManager.DTO;

namespace PasswordManager.Helpers.Validators.Password
{
    public class CreatePasswordDTOValidator : AbstractValidator<CreatePasswordDTO>
    {
        public CreatePasswordDTOValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please enter a name");
            RuleFor(p => p.SiteURL).NotEmpty().WithMessage("Please enter a URL");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Please enter an username");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Please enter a password");
        }
    }
}
