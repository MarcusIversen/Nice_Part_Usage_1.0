using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Core.Entities;
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
        try
        {
            var scores = _scoreRepository.GetAllScores();
            return scores;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public async Task<Score> DeleteScore(string scoreId)
    {
        if (string.IsNullOrEmpty(scoreId))
            throw new ArgumentException("id cannot be null or empty");
        
        try
        {
            var score = await _scoreRepository.DeleteScore(scoreId);
            return score;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
}