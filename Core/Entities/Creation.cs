namespace Core.Entities;

public class Creation
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ElementUsed { get; set; }
    public Guid CreatorId{ get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}