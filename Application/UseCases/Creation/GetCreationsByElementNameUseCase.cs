using Core.Interfaces.Services;

namespace Application.UseCases.Creation;

public class GetCreationsByElementNameUseCase
{
    private readonly ICreationService _creationService;

    public GetCreationsByElementNameUseCase(ICreationService creationService)
    {
        _creationService = creationService;
    }

    // TODO Review if i want this as a database action
    public async Task<IEnumerable<Core.Entities.Creation>> ExecuteAsync(string elementName)
    {
        return await _creationService.SearchByElementName(elementName);
    }
}