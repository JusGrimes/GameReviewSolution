using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using GameReviewSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly GameReviewContext _context;
    private readonly ILogger<GameController> _logger;

    public GameController(GameReviewContext context, ILogger<GameController> logger, IValidator<GameDto> gameDtoValidator)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetGames()
    {
        var gameQuery = from g in _context.Games
            select GameDto.FromEntity(g);

        return Ok(await gameQuery.ToListAsync());
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetGame(int id)
    {
        var gameQuery = from g in _context.Games
            where g.Id == id
            select GameDto.FromEntity(g);
        var game = await gameQuery.SingleOrDefaultAsync();
        
        if (game is not null) return Ok(game);
        
        _logger.LogDebug("Couldn't locate game with id: {Id}", id);
        return NotFound();
    }

    [HttpPost]
    [Route("")]
    public async Create([FromBody] GameDto)
    {
        return OK()
    }
}