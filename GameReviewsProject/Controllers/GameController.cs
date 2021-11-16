using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        this._logger = logger;
    }

    [HttpGet]
    [Route("/{id?}")]
    public Task<ActionResult<GameDto>> GetGame(int id)
    {
        var game = _context.Games.FirstOrDefault(g => g.Id == id);
        return Task.FromResult<ActionResult<GameDto>>(game is not null ? game.ToDto() : NotFound());
    }
    
}