using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public interface IGameRepoService : IRepoService<Game, GameDto>
{
}

public class GameRepoService : IGameRepoService
{
    private readonly GameReviewContext _context;
    private readonly ILogger<GameRepoService> _logger;

    public GameRepoService(GameReviewContext context, ILogger<GameRepoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Game> GetEntityById(int id)
    {
        return await _context.Games.SingleAsync(g => g.Id == id);
    }

    public async Task<GameDto> GetDtoById(int id)
    {
        return DtoFrom(await GetEntityById(id));
    }

    public async Task<IEnumerable<Game>> GetAllEntities()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<IEnumerable<GameDto>> GetAllDtos()
    {
        return (await GetAllEntities()).Select(DtoFrom);
    }

    public Task<Game> EntityFrom(GameDto dto)
    {
        return _context.Games.SingleAsync(
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