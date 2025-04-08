using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

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

    // TODO TEST
    public Task<User> GetUserById(string userId)
    {
        var objectId = new ObjectId(userId);
        var user = _context.Users.FirstOrDefaultAsync(user => user.Id == objectId);
        if(user == null)
            throw new KeyNotFoundException($"No user with id: {userId}");
        return user;
    }

    // TODO TEST
    public Task<User> GetUserByUserName(string userName)
    {
        throw new NotImplementedException();
    }

    // TODO TEST
    public Task<User> DeleteUserById(string userId)
    {
        throw new NotImplementedException();
    }
}