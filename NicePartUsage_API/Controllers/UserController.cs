using Application.UseCases.User;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using NicePartUsage_API.Controllers.DTOs.User;

namespace NicePartUsage_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly AddUserUseCase _addUserUseCase;
    private readonly GetUserByIdUseCase _getUserByIdUseCase;
    private readonly DeleteUserUseCase _deleteUserUseCase;

    public UserController(
        IMapper mapper,
        AddUserUseCase addUserUseCase,
        GetUserByIdUseCase getUserByIdUseCase,
        DeleteUserUseCase deleteUserUseCase)
    {
        _mapper = mapper;
        _addUserUseCase = addUserUseCase;
        _getUserByIdUseCase = getUserByIdUseCase;
        _deleteUserUseCase = deleteUserUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddUserDto dto)
    {
        try
        {
            var mappedUser = _mapper.Map<User>(dto);
            var createdUser = await _addUserUseCase.ExecuteAsync(mappedUser);
            return StatusCode(201, createdUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
    {
        try
        {
            var user = await _getUserByIdUseCase.ExecuteAsync(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] string id)
    {
        try
        {
            var user = await _deleteUserUseCase.ExecuteAsync(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }    
    
}