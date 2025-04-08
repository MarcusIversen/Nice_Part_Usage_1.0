using MongoDB.Bson;

namespace NicePartUsage_API.Controllers.DTOs.Creation;

public class UpdateCreationDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ElementUsed { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}