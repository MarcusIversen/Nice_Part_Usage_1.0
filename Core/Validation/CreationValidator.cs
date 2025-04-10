using Core.Entities;
using FluentValidation;

namespace Core.Validation;

public class CreationValidator : AbstractValidator<Creation>
{
    public CreationValidator()
    {
        RuleFor(score => score.Title).NotEmpty();
        RuleFor(score => score.Description).NotEmpty();
        RuleFor(score => score.ImageUrl).NotEmpty();
        RuleFor(score => score.ElementUsed).NotEmpty();
    }
}