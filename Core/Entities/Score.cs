namespace Core.Entities;

public class Score
{
    public string Id { get; set; }
    public string CreationId { get; set; }
    public string UserId { get; set; }
    public double CreativityScore { get; set; }
    public double UniquenessScore { get; set; }
    public DateTime CreatedAt { get; set; }
}