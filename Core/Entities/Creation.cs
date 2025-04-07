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

    public Creation(Guid id, string title, string description, string imageUrl, string elementUsed, Guid creatorId, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
        ElementUsed = elementUsed;
        CreatorId = creatorId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}