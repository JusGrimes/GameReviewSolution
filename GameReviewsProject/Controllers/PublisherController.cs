using System;
using System.Threading.Tasks;
using GameReviewSolution.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly ILogger<PublisherController> _logger;
    private readonly IPublisherRepoService _publisherRepoService;

    public PublisherController(IPublisherRepoService publisherRepoService,
        ILogger<PublisherController> logger)
    {
        _publisherRepoService = publisherRepoService;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetAll()
    {
        var publisherDtos = await _publisherRepoService.GetAllDtos();
        _logger.LogInformation("Publishers found : {PublisherCount}", publisherDtos.Count);
        if (publisherDtos.Count == 0) return NoContent();
        return Ok(publisherDtos);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        try
        {
            var publisherDto = await _publisherRepoService.GetDtoById(id);
            _logger.LogInformation("Found publisher with Id: {Id}", id);
            return Ok(publisherDto);
        }
        catch (InvalidOperationException)
        {
            _logger.LogInformation("Couldn't locate publisher with Id: {Id}", id);
            return NotFound();
        }
    }
}