using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.MongoDB;

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
        throw new NotImplementedException();
    }

    public Task<User> GetUserByUserName(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserById(string userId)
    {
        throw new NotImplementedException();
    }
}