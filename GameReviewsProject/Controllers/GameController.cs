using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using GameReviewSolution.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IService<Game, GameDto> _gameService;
    private readonly ILogger<GameController> _logger;

    public GameController(IService<Game, GameDto> gameService, ILogger<GameController> logger)
    {
        _gameService = gameService;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetGames()
    {
        var gameList = _gameService.GetAllDtos();
        _logger.LogInformation("Games found : {GamesFound}", gameList.Count);
        if (gameList.Count == 0) return NotFound();
        return Ok(gameList);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetGame(int id)
    {
        GameDto gameDto;
        try
        {
            gameDto = _gameService.GetDtoById(id);
            _logger.LogInformation("Found Game with Id: {Id}", id);
        }
        catch (InvalidOperationException e)
        {
            _logger.LogInformation("Game not found with Id: {Id}", id);
            return NotFound();
        }

        return Ok(gameDto);
    }
}