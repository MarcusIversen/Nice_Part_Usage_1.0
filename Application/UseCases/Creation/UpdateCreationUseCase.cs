using Application.Interfaces.Services;

namespace Application.UseCases.Creation;

public class UpdateCreationUseCase
{
    private readonly ICreationService _creationService;

    public UpdateCreationUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    public async Task<Core.Entities.Creation> ExecuteAsync(Core.Entities.Creation newCreation)
    {
        var existingCreation = await _creationService.GetCreationById(newCreation.Id.ToString());
        if (existingCreation == null)
            throw new ArgumentException($"Invalid update, creation with id: {newCreation.Id.ToString()} doesn't exist");

        return await _creationService.UpdateCreation(newCreation, existingCreation);
    }
}