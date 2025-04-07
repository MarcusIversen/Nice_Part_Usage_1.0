using Application.Repositories;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Validation;
using FluentValidation.Results;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly UserValidator _userValidator;
    private readonly IUserRepository _userRepository;

    public UserService(UserValidator userValidator, IUserRepository userRepository)
    {
        _userValidator = userValidator;
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(User user)
    {
        ValidationResult validationResult = _userValidator.Validate(user);
        if (validationResult.IsValid)
        {
            try
            {
                var createdUser = await _userRepository.CreateUser(user);
                return createdUser;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        var errorMessage = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
        throw new ArgumentException($"Invalid user {errorMessage}");
    }

    public async Task<User> GetUserById(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("id cannot be null or empty");

        try
        {
            var user = await _userRepository.GetUserById(userId);
            return user;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public Task<User> GetUserByUserName(string userName)
    {
        // TODO consider if this method is needed
        throw new NotImplementedException();
    }

    public async Task<User> DeleteUserById(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("id cannot be null or empty");
        
        try
        {
            var user = await _userRepository.DeleteUserById(userId);
            return user;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
}