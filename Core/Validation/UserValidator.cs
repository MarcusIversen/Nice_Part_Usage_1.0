using Core.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Username)
            .NotEmpty()
            .Length(3, 20).WithMessage("User name must be between 3 and 20 characters.");
    }
}