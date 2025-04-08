using Application.Interfaces.Services;

namespace Application.UseCases.Creation;

public class DeleteCreationUseCase
{
    private readonly ICreationService _creationService;

    public DeleteCreationUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    public async Task<Core.Entities.Creation> ExecuteAsync(string creationId)
    {
        return await _creationService.DeleteCreation(creationId);
    }
}