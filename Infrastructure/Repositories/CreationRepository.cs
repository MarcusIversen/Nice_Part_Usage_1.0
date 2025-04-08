using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.MongoDB;
using Microsoft.EntityFrameworkCore;

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
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Creation>> SearchByElementName(string elementName)
    {
        throw new NotImplementedException();
    }

    public Task<Creation> UpdateCreation(Creation newCreation, Creation oldCreation)
    {
        throw new NotImplementedException();
    }

    public Task<Creation> DeleteCreation(string creationId)
    {
        throw new NotImplementedException();
    }
}