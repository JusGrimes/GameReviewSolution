using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public interface IReviewPostRepoService : IRepoService<ReviewPost, ReviewPostDto>
{
    Task<IEnumerable<ReviewPost>> GetAllReviewsByGameId(int gameId);

    Task<IEnumerable<ReviewPostDto>> GetAllReviewsByGameIdAsDto(int gameId);
}

public class ReviewPostRepoService : IReviewPostRepoService
{
    private readonly GameReviewContext _context;
    private readonly ILogger<ReviewPostRepoService> _logger;

    public ReviewPostRepoService(GameReviewContext context, ILogger<ReviewPostRepoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<ReviewPost> GetEntityById(int id)
    {
        return _context.ReviewPosts.SingleAsync(post => post.Id == id);
    }

    public async Task<ReviewPostDto> GetDtoById(int id)
    {
        return DtoFrom(await GetEntityById(id));
    }

    public async Task<IEnumerable<ReviewPost>> GetAllEntities()
    {
        return await _context.ReviewPosts.ToListAsync();
    }

    public async Task<IEnumerable<ReviewPostDto>> GetAllDtos()
    {
        return (await GetAllEntities()).Select(DtoFrom);
    }

    public async Task<ReviewPost> EntityFrom(ReviewPostDto dto)
    {
        return await _context.ReviewPosts.SingleAsync(
            r => r.Id == dto.Id);
    }

    public ReviewPostDto DtoFrom(ReviewPost entity)
    {
        return new ReviewPostDto
        {
            Id = entity.Id,
            GameId = entity.Game.Id,
            UserId = entity.Author.Id,
            Rating = entity.Rating,
            ReviewText = entity.ReviewText
        };
    }

    public async Task<IEnumerable<ReviewPost>> GetAllReviewsByGameId(int gameId)
    {
        return await _context.ReviewPosts.Where(post => post.Game.Id == gameId).ToListAsync();
    }

    public async Task<IEnumerable<ReviewPostDto>> GetAllReviewsByGameIdAsDto(int gameId)
    {
        return (await GetAllReviewsByGameId(gameId)).Select(DtoFrom);
    }
}