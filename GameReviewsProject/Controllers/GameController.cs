using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameRepoService _gameRepoService;
    private readonly ILogger<GameController> _logger;

    public GameController(IGameRepoService gameRepoService, ILogger<GameController> logger)
    {
        _gameRepoService = gameRepoService;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
    {
        var gameList = await _gameRepoService.GetAllDtos();
        _logger.LogInformation("Games found : {GamesFound}", gameList.Count);
        if (gameList.Count == 0) return NoContent();
        return Ok(gameList);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GameDto>> GetById(int id)
    {
        try
        {
            var gameDto = await _gameRepoService.GetDtoById(id);
            _logger.LogInformation("Found Game with Id: {Id}", id);
            return Ok(gameDto);
        }
        catch (InvalidOperationException)
        {
            _logger.LogInformation("Game not found with Id: {Id}", id);
            return NotFound();
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<GameDto>> CreateGame(GameDto dto)
    {
        try
        {
            var createdGameDto = await _gameRepoService.Add(dto);
            return Ok(createdGameDto);
        }
        catch (Exception e) when (e is DbUpdateException or InvalidOperationException)
        {
            _logger.LogError("Unable to create Game with id: {Id} and Title: {Title}", dto.Id, dto.Title);
            return Conflict();
        }
    }
}