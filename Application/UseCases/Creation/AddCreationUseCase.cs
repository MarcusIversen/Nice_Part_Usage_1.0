using Core.Interfaces.Services;

namespace Application.UseCases.Creation;

public class AddCreationUseCase
{
    private readonly ICreationService _creationService;

    public AddCreationUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    public async Task<Core.Entities.Creation> ExecuteAsync(Core.Entities.Creation newCreation)
    {
        return await _creationService.CreateCreation(newCreation);
    }
}