using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly GameReviewContext _context;

        public ReviewController(GameReviewContext context, ILogger<ReviewController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private readonly ILogger<ReviewController> _logger;

        public async Task<IActionResult> GetAllReviews()
        {
            var reviewsQuery = from r in _context.ReviewPosts
                select ReviewPostDto.FromEntity(r);
            return Ok(await reviewsQuery.ToListAsync());
        }
    }
}