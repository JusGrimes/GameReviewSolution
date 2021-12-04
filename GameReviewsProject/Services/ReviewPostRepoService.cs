using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public interface IReviewPostRepoService : IRepoService<ReviewPost, ReviewPostDto>
{
    ICollection<ReviewPost> GetAllReviewsByGameId(int gameId);

    ICollection<ReviewPostDto> GetAllReviewsByGameIdAsDto(int gameId);
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

    public ReviewPost GetEntityById(int id)
    {
        return _context.ReviewPosts.Single(post => post.Id == id);
    }

    public ReviewPostDto GetDtoById(int id)
    {
        return DtoFrom(GetEntityById(id));
    }

    public ICollection<ReviewPost> GetAllEntities()
    {
        return _context.ReviewPosts.ToImmutableList();
    }

    public ICollection<ReviewPostDto> GetAllDtos()
    {
        return GetAllEntities().Select(DtoFrom).ToImmutableList();
    }

    public ReviewPost EntityFrom(ReviewPostDto dto)
    {
        return _context.ReviewPosts.Single(
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

    public ICollection<ReviewPost> GetAllReviewsByGameId(int gameId)
    {
        return _context.ReviewPosts.Where(post => post.Game.Id == gameId)
            .ToImmutableList();
    }

    public ICollection<ReviewPostDto> GetAllReviewsByGameIdAsDto(int gameId)
    {
        return GetAllReviewsByGameId(gameId).Select(DtoFrom).ToImmutableList();
    }
}