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
    [Route("{gameId:int}")]
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