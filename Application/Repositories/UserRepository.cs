using Core.Entities;
using Core.Interfaces.Repositories;

namespace Application.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> CreateUser(User user)
    {
        throw new NotImplementedException();
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