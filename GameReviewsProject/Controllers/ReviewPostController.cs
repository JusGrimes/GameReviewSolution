using System;
using System.Threading.Tasks;
using GameReviewSolution.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewPostController : ControllerBase
{
    private readonly ILogger<ReviewPostController> _logger;
    private readonly IReviewPostRepoService _reviewPostRepoService;

    public ReviewPostController(IReviewPostRepoService reviewPostRepoService, ILogger<ReviewPostController> logger)
    {
        _reviewPostRepoService = reviewPostRepoService;
        _logger = logger;
    }

    [HttpGet]
    [Route("game/{gameId:int}")]
    public async Task<IActionResult> GetAllByGame(int gameId)
    {
        var reviewList = await _reviewPostRepoService.GetAllReviewsByGameId(gameId);
        _logger.LogDebug("located {Count} reviews with gameId:{GameId}", reviewList.Count, gameId);
        if (reviewList.Count == 0)
            return NotFound();
        return Ok(reviewList);
    }

    [HttpGet]
    [Route("review/{reviewId}")]
    public async Task<IActionResult> GetReviewById(int reviewId)
    {
        try
        {
            var review = await _reviewPostRepoService.GetDtoById(reviewId);
            _logger.LogInformation("Found publisher with Id: {ReviewId}", reviewId);
            return Ok(review);
        }
        catch (InvalidOperationException)
        {
            _logger.LogInformation("Couldn't locate publisher with Id: {ReviewId}", reviewId);
            return NotFound();
        }
    }
}