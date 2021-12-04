using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

internal interface IPublisherRepoService : IRepoService<Publisher, PublisherDto>
{
}

public class PublisherRepoService : IPublisherRepoService
{
    private readonly GameReviewContext _context;
    private readonly ILogger<PublisherRepoService> _logger;

    public PublisherRepoService(GameReviewContext context, ILogger<PublisherRepoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Publisher GetEntityById(int id)
    {
        return _context.Publishers.Single(p => p.Id == id);
    }

    public PublisherDto GetDtoById(int id)
    {
        return DtoFrom(GetEntityById(id));
    }

    public ICollection<Publisher> GetAllEntities()
    {
        return _context.Publishers.ToImmutableList();
    }

    public ICollection<PublisherDto> GetAllDtos()
    {
        return GetAllEntities().Select(DtoFrom).ToImmutableList();
    }

    public Publisher EntityFrom(PublisherDto dto)
    {
        return null;
    }

    public PublisherDto DtoFrom(Publisher entity)
    {
        return new PublisherDto
        {
            Id = entity.Id,
            Name = entity.Name,
            WebsiteUri = entity.WebsiteUri
        };
    }
}