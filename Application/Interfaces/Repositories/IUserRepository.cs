using Core.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<User> CreateUser(User user);
    public Task<User> GetUserById(string userId);
    public Task<User> DeleteUserById(string userId);
    
}