namespace Core.Entities;

public class Score
{
    public Guid Id { get; set; }
    public Guid CreationId { get; set; }
    public Guid UserId { get; set; }
    public double ScoreValue { get; set; }
    public DateTime CreatedAt { get; set; }
}