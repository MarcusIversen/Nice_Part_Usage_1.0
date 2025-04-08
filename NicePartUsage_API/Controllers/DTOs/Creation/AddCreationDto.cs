using MongoDB.Bson;

namespace NicePartUsage_API.Controllers.DTOs.Creation;

public class AddCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string ElementUsed { get; set; }
    public string CreatorId{ get; set; }
    public DateTime? CreatedAt{ get; set; } = DateTime.UtcNow;
}