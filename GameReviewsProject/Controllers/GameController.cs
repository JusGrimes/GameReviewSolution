using System;
using System.Threading.Tasks;
using GameReviewSolution.Services;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAll()
    {
        var gameList = await _gameRepoService.GetAllDtos();
        _logger.LogInformation("Games found : {GamesFound}", gameList.Count);
        if (gameList.Count == 0) return NoContent();
        return Ok(gameList);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
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
}