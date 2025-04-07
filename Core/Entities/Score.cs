namespace Core.Entities;

public class Score
{
    public Guid Id { get; set; }
    public Guid CreationId { get; set; }
    public Guid UserId { get; set; }
    public double CreativityScore { get; set; }
    public double UniquenessScore { get; set; }
    public DateTime CreatedAt { get; set; }
}