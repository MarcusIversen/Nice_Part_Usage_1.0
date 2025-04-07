namespace Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User(Guid id, string username, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Username = username;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}