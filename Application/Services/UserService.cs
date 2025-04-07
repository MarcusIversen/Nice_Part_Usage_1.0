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

    public Task<User> CreateUser(User user)
    {
        ValidationResult validationResult = _userValidator.Validate(user);
        if (validationResult.IsValid)
        {
            try
            {
                var createdUser = _userRepository.CreateUser(user);
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