using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Validation;
using FluentValidation.Results;

namespace Application.Services;

public class ScoreService : IScoreService
{
    
    private readonly ScoreValidator _scoreValidator;
    private readonly IScoreRepository _scoreRepository;

    public ScoreService(ScoreValidator scoreValidator, IScoreRepository scoreRepository)
    {
        _scoreValidator = scoreValidator;
        _scoreRepository = scoreRepository;
    }

    public Task<Score> CreateScore(Score score)
    {
        ValidationResult validationResult = _scoreValidator.Validate(score);
        if (validationResult.IsValid)
        {
            try
            {
                var createdScore = _scoreRepository.CreateScore(score);
                return createdScore;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        var errorMessage = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
        throw new ArgumentException($"Invalid score {errorMessage}");
    }

    public Task<IEnumerable<Score>> GetAllScores()
    {
        throw new NotImplementedException();
    }

    public Task<Score> DeleteScore(Score score)
    {
        throw new NotImplementedException();
    }
}