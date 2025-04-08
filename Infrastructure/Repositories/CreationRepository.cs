using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.MongoDB;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Infrastructure.Repositories;

public class CreationRepository: ICreationRepository
{
    private readonly DatabaseContext _context;

    public CreationRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Creation> CreateCreation(Creation creation)
    {
        await _context.Creations.AddAsync(creation);
        await _context.SaveChangesAsync();
        return creation;
    }

    public async Task<IEnumerable<Creation>> GetAllCreations()
    {
        var allCreations = await _context.Creations.ToListAsync();
        return allCreations;
    }

    public Task<Creation> GetCreationById(string creationId)
    {
        var objectId = new ObjectId(creationId);
        var creation = _context.Creations.FirstOrDefaultAsync(creation => creation.Id == objectId);
        if (creation == null)
            throw new KeyNotFoundException($"No creation with id: {creationId}");
        return creation;

    }

    public async Task<IEnumerable<Creation>> SearchByElementName(string elementName)
    {
        if (string.IsNullOrWhiteSpace(elementName))
        {
            throw new ArgumentException("Element name cannot be null or empty.", nameof(elementName));
        }

        var results = await _context.Creations
            .Where(creation => creation.ElementUsed.Contains(elementName))
            .ToListAsync();

        return results;
        
    }

    public async Task<Creation> UpdateCreation(Creation newCreation, Creation oldCreation)
    {
        var creationToUpdate = await GetCreationById(newCreation.Id.ToString());

        if (oldCreation.Id != newCreation.Id)
            throw new ArgumentException($"Ids doesnt match ids: {newCreation.Id} and {oldCreation.Id}");
        
        creationToUpdate.Title = newCreation.Title;
        creationToUpdate.Description = newCreation.Description;
        creationToUpdate.ImageUrl = newCreation.ImageUrl;
        creationToUpdate.ElementUsed = newCreation.ElementUsed;
        creationToUpdate.UpdatedAt = DateTime.UtcNow;

        
        _context.Creations.Update(creationToUpdate);
        await _context.SaveChangesAsync();

        return creationToUpdate;
    }

    public async Task<Creation> DeleteCreation(string creationId)
    {
        var objectId = new ObjectId(creationId);
        var creationToDelete = await _context.Creations.FirstOrDefaultAsync(creation => creation.Id == objectId);
        if (creationToDelete == null)
            throw new KeyNotFoundException($"No creation with id: {creationId}");
        _context.Creations.Remove(creationToDelete);
        await _context.SaveChangesAsync();
        return creationToDelete;
    }
}