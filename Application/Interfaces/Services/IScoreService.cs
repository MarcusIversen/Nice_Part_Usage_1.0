using Core.Entities;

namespace Application.Interfaces.Services;

public interface IScoreService
{
    public Task<Score> CreateScore(Score score);
    public Task<IEnumerable<Score>> GetAllScores();
    
    public Task<Score> DeleteScore(string scoreId);
}