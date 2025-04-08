using Application.Interfaces.Services;

namespace Application.UseCases.User;

public class AddUserUseCase
{
    private readonly IUserService _userService;

    public AddUserUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Core.Entities.User> ExecuteAsync(Core.Entities.User newUser)
    {
        return await _userService.CreateUser(newUser);
    }
}