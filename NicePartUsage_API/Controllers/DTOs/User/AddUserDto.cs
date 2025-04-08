namespace NicePartUsage_API.Controllers.DTOs.User;

public class AddUserDto
{
    public string Username { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}