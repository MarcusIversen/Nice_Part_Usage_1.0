using MongoDB.Bson;

namespace NicePartUsage_API.Controllers.DTOs.Score;

public class AddScoreDto
{
    public string CreationId { get; set; }
    public string UserId { get; set; }
    public double CreativityScore { get; set; }
    public double UniquenessScore { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}