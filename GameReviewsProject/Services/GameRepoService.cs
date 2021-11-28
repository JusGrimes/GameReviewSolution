﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public class GameRepoService : IRepoService<Game, GameDto>
{
    private readonly GameReviewContext _context;
    private readonly ILogger<GameRepoService> _logger;


    public GameRepoService(GameReviewContext context, ILogger<GameRepoService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public Game GetEntityById(int id)
    {
        return _context.Games.Single(g => g.Id == id);
    }

    public GameDto GetDtoById(int id) => DtoFrom(GetEntityById(id));

    public ICollection<Game> GetAllEntities()
    {
        var query = from g in _context.Games
            select g;
        return query.ToImmutableList();
    }

    public ICollection<GameDto> GetAllDtos() => GetAllEntities().Select(DtoFrom).ToImmutableList();

    public Game EntityFrom(GameDto dto)
    {
        return _context.Games.Single(
            g =>
                g.Title == dto.Title &&
                g.GamePublisher.Name.ToUpperInvariant() ==
                dto.PublisherName.ToUpperInvariant()
        );
    }
    public GameDto DtoFrom(Game entity)
    {
        return new GameDto
        {
            Id = entity.Id,
            Title = entity.Title,
            ReleaseDate = entity.ReleaseDate,
            GameWebsiteUri = entity.GameUri,
            PublisherName = entity.GamePublisher.Name,
            PublisherWebsiteUri = entity.GamePublisher.WebsiteUri
        };
    }
}