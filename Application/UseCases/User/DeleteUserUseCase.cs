using Core.Interfaces.Services;

namespace Application.UseCases.User;

public class DeleteUserUseCase
{
    private readonly IUserService _userService;

    public DeleteUserUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Core.Entities.User> ExecuteAsync(string userId)
    {
        return await _userService.DeleteUserById(userId);
    }
}