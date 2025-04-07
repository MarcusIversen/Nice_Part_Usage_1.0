using Core.Entities;

namespace Core.Interfaces.Services;

public interface ICreationService
{
    public Task<Creation> CreateCreation(Creation creation);
    public Task<IEnumerable<Creation>> GetAllCreations();

    public Task<Creation> GetCreationById(string creationId);
    public Task<IEnumerable<Creation>> SearchByElementName(string elementName);

    public Task<Creation> UpdateCreation(Creation creation);

    public Task<Creation> DeleteCreation(string creationId);
}