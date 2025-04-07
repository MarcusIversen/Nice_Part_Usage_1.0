using Core.Entities;
using Core.Interfaces.Repositories;

namespace Application.Repositories;

public class CreationRepository: ICreationRepository
{
    public Task<Creation> CreateCreation(Creation creation)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Creation>> GetAllCreations()
    {
        throw new NotImplementedException();
    }

    public Task<Creation> GetCreationById(string creationId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Creation>> SearchByElementName(string elementName)
    {
        throw new NotImplementedException();
    }

    public Task<Creation> UpdateCreation(Creation creation)
    {
        throw new NotImplementedException();
    }

    public Task<Creation> DeleteCreation(string creationId)
    {
        throw new NotImplementedException();
    }
}