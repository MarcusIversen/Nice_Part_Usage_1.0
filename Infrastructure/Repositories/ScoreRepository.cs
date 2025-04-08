using Application.Interfaces.Repositories;
using Core.Entities;
using Infrastructure.MongoDB;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Infrastructure.Repositories;

public class ScoreRepository : IScoreRepository
{
    private readonly DatabaseContext _context;

    public ScoreRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Score> CreateScore(Score score)
    {
        await _context.Scores.AddAsync(score);
        await _context.SaveChangesAsync();
        return score;
    }

    public async Task<IEnumerable<Score>> GetAllScores()
    {
        var allScores = await _context.Scores.ToListAsync();
        return allScores;
    }

    public async Task<Score> DeleteScore(string scoreId)
    {
        var objectId = new ObjectId(scoreId);
        var scoreToDelete = await _context.Scores.FirstOrDefaultAsync(score => score.Id == objectId);
        if (scoreToDelete == null)
            throw new KeyNotFoundException($"No score with id: {scoreId}");
        _context.Scores.Remove(scoreToDelete);
        await _context.SaveChangesAsync();
        return scoreToDelete;
    }
}