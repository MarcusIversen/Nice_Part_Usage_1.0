using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IScoreRepository
{
    public Task<Score> CreateScore(Score score);
    public Task<IEnumerable<Score>> GetAllScores();
    
    public Task<Score> DeleteScore(string scoreId);
}