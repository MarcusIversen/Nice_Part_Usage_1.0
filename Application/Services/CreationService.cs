using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Validation;
using FluentValidation.Results;

namespace Application.Services;

public class CreationService : ICreationService
{

    private readonly CreationValidator _creationValidator;
    private readonly ICreationRepository _creationRepository;

    public CreationService(CreationValidator creationValidator, ICreationRepository creationRepository)
    {
        _creationValidator = creationValidator;
        _creationRepository = creationRepository;
    }

    public Task<Creation> CreateCreation(Creation creation)
    {
        ValidationResult validationResult = _creationValidator.Validate(creation);
        if (validationResult.IsValid)
        {
            try
            {
                var createdCreation = _creationRepository.CreateCreation(creation);
                return createdCreation;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        var errorMessage = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
        throw new ArgumentException($"Invalid creation {errorMessage}");
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