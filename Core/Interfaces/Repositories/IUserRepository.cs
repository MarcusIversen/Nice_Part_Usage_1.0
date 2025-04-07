using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<User> CreateUser(User user);
    public Task<User> GetUserById(string userId);
    
    public Task<User> GetUserByUserName(string userName);
    public Task<User> DeleteUserById(string userId);
    
}