using Core.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Id).NotEmpty();
        RuleFor(user => user.Username)
            .NotEmpty()
            .Length(3, 20).WithMessage("User name must be between 3 and 20 characters.");
        RuleFor(user => user.CreatedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("CreatedAt cannot be in the future");        
        RuleFor(user => user.UpdatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .When(user => user.UpdatedAt.HasValue)
            .WithMessage("UpdatedAt cannot be in the future.");
    }
}