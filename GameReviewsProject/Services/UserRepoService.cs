using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.Extensions.Logging;

namespace GameReviewSolution.Services;

public interface IUserRepoService : IRepoService<User, UserDto>
{
}

public class UserRepoService : IUserRepoService
{
    private readonly GameReviewContext _context;
    private readonly ILogger<UserRepoService> _logger;

    public UserRepoService(GameReviewContext context, ILogger<UserRepoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public User GetEntityById(int id)
    {
        return _context.Users.Single(user => user.Id == id);
    }

    public UserDto GetDtoById(int id)
    {
        return DtoFrom(GetEntityById(id));
    }

    public ICollection<User> GetAllEntities()
    {
        return _context.Users.ToImmutableList();
    }

    public ICollection<UserDto> GetAllDtos()
    {
        return GetAllEntities().Select(DtoFrom).ToImmutableList();
    }

    public User EntityFrom(UserDto dto)
    {
        return GetEntityById(dto.Id);
    }

    public UserDto DtoFrom(User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Username = entity.Username
        };
    }
}