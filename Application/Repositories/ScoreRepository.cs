using Core.Entities;
using Core.Interfaces.Repositories;

namespace Application.Repositories;

public class ScoreRepository : IScoreRepository
{
    public Task<Score> CreateScore(Score score)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Score>> GetAllScores()
    {
        throw new NotImplementedException();
    }

    public Task<Score> DeleteScore(string scoreId)
    {
        throw new NotImplementedException();
    }

    public Task<Score> DeleteScore(Score score)
    {
        throw new NotImplementedException();
    }
}