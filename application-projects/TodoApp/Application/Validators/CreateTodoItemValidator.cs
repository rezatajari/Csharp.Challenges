using Application.Shared.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTodoItemValidator:AbstractValidator<CreateTodoItem>
    {
        public CreateTodoItemValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("The title is not empty.")
                .MaximumLength(100)
                .WithMessage("The title is not grather than 100.");
        }
    }
}
