using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public interface IPublisherRepoService : IRepoService<Publisher, PublisherDto>
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

    public Task<PublisherDto> Add(PublisherDto dtoInput)
    {
        return null;
    }

    public async Task<Publisher> GetEntityById(int id)
    {
        return await _context.Publishers.SingleAsync(p => p.Id == id);
    }

    public async Task<PublisherDto> GetDtoById(int id)
    {
        return DtoFrom(await GetEntityById(id));
    }

    public async Task<IList<Publisher>> GetAllEntities()
    {
        return await _context.Publishers.ToListAsync();
    }

    public async Task<IList<PublisherDto>> GetAllDtos()
    {
        return (await GetAllEntities()).Select(DtoFrom).ToList();
    }

    public Task<Publisher> EntityFrom(PublisherDto dto)
    {
        return _context.Publishers.SingleAsync(publisher => publisher.Id == dto.Id);
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