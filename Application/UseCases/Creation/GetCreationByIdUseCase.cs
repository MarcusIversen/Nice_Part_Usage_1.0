using Application.Interfaces.Services;

namespace Application.UseCases.Creation;

public class GetCreationByIdUseCase
{
    private readonly ICreationService _creationService;

    public GetCreationByIdUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    public async Task<Core.Entities.Creation> ExecuteAsync(string creationId)
    {
        return await _creationService.GetCreationById(creationId);
    }
    
}