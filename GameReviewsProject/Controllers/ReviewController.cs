using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]")]
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
    [Route("")]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviewsQuery = from r in _context.ReviewPosts
            select ReviewPostDto.FromEntity(r);
        return Ok(await reviewsQuery.ToListAsync());
    }
}