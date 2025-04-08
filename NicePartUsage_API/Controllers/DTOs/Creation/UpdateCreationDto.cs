using MongoDB.Bson;

namespace NicePartUsage_API.Controllers.DTOs.Creation;

public class UpdateCreationDto
{
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ElementUsed { get; set; }
    public string CreatorId{ get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}