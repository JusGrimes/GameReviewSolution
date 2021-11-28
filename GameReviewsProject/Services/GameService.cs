using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public class GameService : IService<Game, GameDto>
{
    private readonly GameReviewContext _context;
    private readonly ILogger<GameService> _logger;


    public GameService(GameReviewContext context, ILogger<GameService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public Game GetEntityById(int id)
    {
        var query = from g in _context.Games
            where g.Id == id
            select g;
        return query.Single();
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
        var query = from g in _context.Games
            where g.Title == dto.Title &&
                  g.GamePublisher.Name.ToUpperInvariant() == dto.PublisherName.ToUpperInvariant()
            select g;
        return query.Single();
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