using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class LoginUserRequestValidator:AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.Username)
             .MaximumLength(100).WithMessage("Username should not grather than 100.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
