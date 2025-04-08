using Core.Entities;

namespace Application.Interfaces.Services;

public interface IUserService
{
    public Task<User> CreateUser(User user);
    public Task<User> GetUserById(string userId);
    
    public Task<User> DeleteUserById(string userId);
}