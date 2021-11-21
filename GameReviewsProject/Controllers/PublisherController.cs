using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly GameReviewContext _context;
    private readonly ILogger<PublisherController> _logger;

    public PublisherController(GameReviewContext context, ILogger<PublisherController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetPublisher()
    {
        var publisherQuery = from p in _context.Publishers
            select PublisherDto.FromEntity(p);
        return Ok(await publisherQuery.ToListAsync());
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult> GetPublisher(int id)
    {
        var publisherQuery = from p in _context.Publishers
            where p.Id == id
            select PublisherDto.FromEntity(p);
        var publisher = await publisherQuery.SingleOrDefaultAsync();
        if (publisher is null)
        {
            _logger.LogDebug("Couldn't locate publisher with {Id}", id);
            return NotFound();
        }

        return Ok(publisher);
    }
}