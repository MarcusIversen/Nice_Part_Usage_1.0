using Core.Interfaces.Services;

namespace Application.UseCases.Creation;

public class AddOrUpdateCreationUseCase
{
    private readonly ICreationService _creationService;

    public AddOrUpdateCreationUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    public async Task<Core.Entities.Creation> ExecuteAsync(Core.Entities.Creation newCreation)
    {
        var existingCreations = await _creationService.GetAllCreations();
        var existingCreation = existingCreations.FirstOrDefault(c => c.Id == newCreation.Id);

        if (existingCreation != null)
        {
            return await _creationService.UpdateCreation(newCreation, existingCreation);
        }
        else
        {
            return await _creationService.CreateCreation(newCreation);
        }
    }
}