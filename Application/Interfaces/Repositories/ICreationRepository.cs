using Core.Entities;

namespace Application.Interfaces.Repositories;

public interface ICreationRepository
{
    public Task<Creation> CreateCreation(Creation creation);
    public Task<IEnumerable<Creation>> GetAllCreations();

    public Task<Creation> GetCreationById(string creationId);
    public Task<IEnumerable<Creation>> SearchByElementName(string elementName);

    public Task<Creation> UpdateCreation(Creation newCreation, Creation oldCreation);

    public Task<Creation> DeleteCreation(string creationId);
}