using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly GameReviewContext _context;

    private readonly ILogger<ReviewController> _logger;

    public ReviewController(GameReviewContext context, ILogger<ReviewController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("game/{gameId:int}/review/{reviewId:int}")]
    public async Task<IActionResult> GetAllGameReviews(int gameId, int reviewId)
    {
        var reviewsQuery = from r in _context.ReviewPosts
            where r.GameId == gameId && r.Id == reviewId
            select ReviewPostDto.FromEntity(r);
        var result = await reviewsQuery.SingleOrDefaultAsync();

        if (result is not null) return Ok(result);
        _logger.LogDebug("Couldn't locate review with ReviewId:{ReviewId} and gameId:{GameId}", reviewId, gameId);
        return NotFound();
    }


    [HttpGet]
    [Route("game/{gameId:int}")]
    public async Task<IActionResult> GetAllGameReviewsById(int gameId)
    {
        var reviewsQuery = from r in _context.ReviewPosts
            where r.GameId == gameId
            select ReviewPostDto.FromEntity(r);

        var reviewPostDtos = await reviewsQuery.ToListAsync();
        if (reviewPostDtos.Count == 0) return NoContent();

        return Ok(reviewPostDtos);
    }
}