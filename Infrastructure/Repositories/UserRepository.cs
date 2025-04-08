using System.Data;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.MongoDB;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public Task<User> GetUserById(string userId)
    {
        var objectId = new ObjectId(userId);
        var user = _context.Users.FirstOrDefaultAsync(user => user.Id == objectId);
        if (user == null)
            throw new KeyNotFoundException($"No user with id: {userId}");
        return user;
    }

    public async Task<User> DeleteUserById(string userId)
    {
        var objectId = new ObjectId(userId);
        var userToDelete = await _context.Users.FirstOrDefaultAsync(user => user.Id == objectId);
        if (userToDelete == null)
            throw new KeyNotFoundException($"No user with id: {userId}");
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return userToDelete;
    }
}