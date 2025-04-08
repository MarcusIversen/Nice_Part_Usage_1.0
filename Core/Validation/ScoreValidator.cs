using Core.Entities;
using FluentValidation;

namespace Core.Validation;

public class ScoreValidator : AbstractValidator<Score>
{
    public ScoreValidator()
    {
        RuleFor(score => score.CreationId).NotEmpty();
        RuleFor(score => score.UserId).NotEmpty();
        RuleFor(score => score.CreativityScore).NotEmpty();
        RuleFor(score => score.UniquenessScore).NotEmpty();;
    }
}