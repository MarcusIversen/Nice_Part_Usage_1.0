using Application.Interfaces.Services;

namespace Application.UseCases.Score;

public class GetScoresUseCase
{
    private readonly IScoreService _scoreService;

    public GetScoresUseCase(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }
    
    public async Task<IEnumerable<Core.Entities.Score>> ExecuteAsync()
    {
        return await _scoreService.GetAllScores();
    }
}