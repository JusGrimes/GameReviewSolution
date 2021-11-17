using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
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
    [Route("/{id?}")]
    public ActionResult<GameDto> GetGame(int id)
    {
        var gameQuery = from g in _context.Games
            where g.Id == id
            select g.ToDto();
        var game = gameQuery.FirstOrDefault();
        if (game is null)
        {
            _logger.LogDebug("Couldn't locate game with {Id}", id);
            return NotFound();
        }
        return game;
    }
}