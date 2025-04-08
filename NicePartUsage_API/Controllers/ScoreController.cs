using Application.UseCases.Score;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using NicePartUsage_API.Controllers.DTOs.Score;

namespace NicePartUsage_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly AddScoreUseCase _addScoreUseCase;
    private readonly DeleteScoreUseCase _deleteScoreUseCase;
    private readonly GetScoresUseCase _getScoresUseCase;

    public ScoreController(IMapper mapper, AddScoreUseCase addScoreUseCase, DeleteScoreUseCase deleteScoreUseCase, GetScoresUseCase getScoresUseCase)
    {
        _mapper = mapper;
        _addScoreUseCase = addScoreUseCase;
        _deleteScoreUseCase = deleteScoreUseCase;
        _getScoresUseCase = getScoresUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSCore([FromBody] AddScoreDto dto)
    {
        try
        {
            var mappedScore = _mapper.Map<Score>(dto);
            var createdScore = await _addScoreUseCase.ExecuteAsync(mappedScore);
            return StatusCode(201, createdScore);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetScores()
    {
        try
        {
            var scores = await _getScoresUseCase.ExecuteAsync();
            return Ok(scores);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteScoreById([FromRoute] string id)
    {
        try
        {
            var score = await _deleteScoreUseCase.ExecuteAsync(id);
            return Ok(score);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
    
}