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

    public async Task<Creation> CreateCreation(Creation creation)
    {
        ValidationResult validationResult = _creationValidator.Validate(creation);
        if (validationResult.IsValid)
        {
            try
            {
                var createdCreation = await _creationRepository.CreateCreation(creation);
                return createdCreation;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        var errorMessage = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
        throw new ArgumentException($"Validation error: Invalid creation {errorMessage}");
    }

    public async Task<IEnumerable<Creation>> GetAllCreations()
    {
        try
        {
            var creations = await _creationRepository.GetAllCreations();
            return creations;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public async Task<Creation> GetCreationById(string creationId)
    {
        if (string.IsNullOrEmpty(creationId))
            throw new ArgumentException("id cannot be null or empty");

        try
        {
            var creation = await _creationRepository.GetCreationById(creationId);
            return creation;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public async Task<IEnumerable<Creation>> SearchByElementName(string elementName)
    {
        if (string.IsNullOrEmpty(elementName))
            throw new ArgumentException("Element name cannot be null or empty");

        try
        {
            var elements = await _creationRepository.SearchByElementName(elementName);
            return elements;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }

    }

    public async Task<Creation> UpdateCreation(Creation newCreation, Creation oldCreation)
    {
        if (string.IsNullOrEmpty(newCreation.Id))
            throw new ArgumentException("Id  cannot be null or empty");

        ValidationResult validationResult = _creationValidator.Validate(newCreation);
        
        if (validationResult.IsValid)
        {
            try
            {
                var creation = await _creationRepository.UpdateCreation(newCreation, oldCreation);
                return creation;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        
        var errorMessage = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
        throw new ArgumentException($"Validation error: Invalid creation {errorMessage}");

    }

    public async Task<Creation> DeleteCreation(string creationId)
    {
        if (string.IsNullOrEmpty(creationId))
            throw new ArgumentException("id cannot be null or empty");

        try
        {
            var creation = await _creationRepository.DeleteCreation(creationId);
            return creation;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }
}