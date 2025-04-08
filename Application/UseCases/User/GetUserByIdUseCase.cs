using Core.Interfaces.Services;

namespace Application.UseCases.User;

public class GetUserByIdUseCase
{
    private readonly IUserService _userService;

    public GetUserByIdUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Core.Entities.User> ExecuteAsync(string userId)
    {
        return await _userService.GetUserById(userId);
    }
}