using Core.Entities;
using FluentValidation;

namespace Core.Validation;

public class ScoreValidator : AbstractValidator<Score>
{
    public ScoreValidator()
    {
        RuleFor(score => score.Id).NotEmpty();
        RuleFor(score => score.CreationId).NotEmpty();
        RuleFor(score => score.UserId).NotEmpty();
        RuleFor(score => score.CreativityScore);
        RuleFor(score => score.UniquenessScore);
        RuleFor(score => score.CreatedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("CreatedAt cannot be in the future");
    }
}