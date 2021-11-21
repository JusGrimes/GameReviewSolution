using System.Linq;
using System.Threading.Tasks;
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

    public GameController(GameReviewContext context, ILogger<GameController> logger)
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
        if (game is null)
        {
            _logger.LogDebug("Couldn't locate game with {Id}", id);
            return NotFound();
        }

        return Ok(game);
    }
}