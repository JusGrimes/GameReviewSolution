﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Encodings.Web;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.DotNet.Scaffolding.Shared.ILogger;

namespace GameReviewSolution.Services;

public class PublisherRepoService : IRepoService<Publisher, PublisherDto>
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

    public PublisherDto DtoFrom(Publisher entity) =>
        new()
        {
            Id = entity.Id,
            Name = entity.Name,
            WebsiteUri = entity.WebsiteUri
        };
}