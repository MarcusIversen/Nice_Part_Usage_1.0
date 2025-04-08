using MongoDB.Bson;

namespace Core.Entities;

public class Score
{
    public ObjectId Id { get; set; }
    public ObjectId CreationId { get; set; }
    public ObjectId UserId { get; set; }
    public double CreativityScore { get; set; }
    public double UniquenessScore { get; set; }
    public DateTime CreatedAt { get; set; }
}