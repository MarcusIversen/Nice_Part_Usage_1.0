using Application.Interfaces.Services;

namespace Application.UseCases.Score;

public class DeleteScoreUseCase
{
    private readonly IScoreService _scoreService;

    public DeleteScoreUseCase(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    public async Task<Core.Entities.Score> ExecuteAsync(string scoreId)
    {
        return await _scoreService.DeleteScore(scoreId);
    }
}
