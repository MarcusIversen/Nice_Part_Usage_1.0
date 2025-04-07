using Core.Interfaces.Services;

namespace Application.UseCases.Creation;

public class GetCreationsUseCase
{
    private readonly ICreationService _creationService;

    public GetCreationsUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    public async Task<IEnumerable<Core.Entities.Creation>> ExecuteAsync()
    {
        return await _creationService.GetAllCreations();
    }
    
}