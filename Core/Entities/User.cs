namespace Core.Entities;

using MongoDB.Bson;

public class User
{
    public ObjectId Id { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}