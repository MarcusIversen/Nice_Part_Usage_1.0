using Core.Interfaces.Services;

namespace Application.UseCases.Score;

public class AddScoreUseCase
{
    private readonly IScoreService _scoreService;

    public AddScoreUseCase(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    public async Task<Core.Entities.Score> ExecuteAsync(Core.Entities.Score score)
    {
        return await _scoreService.CreateScore(score);
    }
}