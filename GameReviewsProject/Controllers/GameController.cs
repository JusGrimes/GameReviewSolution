using System;
using System.Threading.Tasks;
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
    private readonly IRepoService<Game, GameDto> _gameRepoService;
    private readonly ILogger<GameController> _logger;

    public GameController(IRepoService<Game, GameDto> gameRepoService, ILogger<GameController> logger)
    {
        _gameRepoService = gameRepoService;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetGames()
    {
        var gameList = _gameRepoService.GetAllDtos();
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
            gameDto = _gameRepoService.GetDtoById(id);
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