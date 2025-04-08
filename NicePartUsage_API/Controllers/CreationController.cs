using Application.UseCases.Creation;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NicePartUsage_API.Controllers.DTOs.Creation;

namespace NicePartUsage_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CreationController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly AddCreationUseCase _addCreationUseCase;
    private readonly UpdateCreationUseCase _updateCreationUseCase;
    private readonly GetCreationsUseCase _getCreationsUseCase;
    private readonly GetCreationByIdUseCase _getCreationByIdUseCase;
    private readonly GetCreationsByElementNameUseCase _getCreationsByElementNameUseCase;
    private readonly DeleteCreationUseCase _deleteCreationUseCase;

    public CreationController(
        IMapper mapper,
        AddCreationUseCase addCreationUseCase,
        UpdateCreationUseCase updateCreationUseCase,
        GetCreationsUseCase getCreationsUseCase,
        GetCreationByIdUseCase getCreationByIdUseCase,
        GetCreationsByElementNameUseCase getCreationsByElementNameUseCase,
        DeleteCreationUseCase deleteCreationUseCase)
    {
        _mapper = mapper;
        _addCreationUseCase = addCreationUseCase;
        _updateCreationUseCase = updateCreationUseCase;
        _getCreationsUseCase = getCreationsUseCase;
        _getCreationByIdUseCase = getCreationByIdUseCase;
        _getCreationsByElementNameUseCase = getCreationsByElementNameUseCase;
        _deleteCreationUseCase = deleteCreationUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCreation([FromBody] AddCreationDto dto)
    {
        try
        {
            var mappedCreation = _mapper.Map<Creation>(dto);
            var createdCreation = await _addCreationUseCase.ExecuteAsync(mappedCreation);
            return StatusCode(201, createdCreation);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCreations()
    {
        try
        {
            var creations = await _getCreationsUseCase.ExecuteAsync();
            return Ok(creations);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCreationById([FromRoute] string creationId)
    {
        try
        {
            var creation = await _getCreationByIdUseCase.ExecuteAsync(creationId);
            return Ok(creation);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCreation([FromBody] UpdateCreationDto dto)
    {
        try
        {
            var mappedCreation = _mapper.Map<Creation>(dto);
            return Ok(await _updateCreationUseCase.ExecuteAsync(mappedCreation));
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet]
    [Route("{elementName}")]
    public async Task<IActionResult> GetCreationsByElementName([FromRoute] string elementName)
    {
        try
        {
            var creation = await _getCreationsByElementNameUseCase.ExecuteAsync(elementName);
            return Ok(creation);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCreationById([FromRoute] string id)
    {
        try
        {
            var creation = await _deleteCreationUseCase.ExecuteAsync(id);
            return Ok(creation);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
}