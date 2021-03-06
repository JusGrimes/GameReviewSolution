using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.EntityFrameworkCore;
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

    public Task<UserDto> Add(UserDto dtoInput)
    {
        return null;
    }

    public async Task<User> GetEntityById(int id)
    {
        return await _context.Users.SingleAsync(user => user.Id == id);
    }

    public async Task<UserDto> GetDtoById(int id)
    {
        return DtoFrom(await GetEntityById(id));
    }

    public async Task<IList<UserDto>> GetAllDtos()
    {
        return (await GetAllEntities()).Select(DtoFrom).ToList();
    }

    public async Task<User> EntityFrom(UserDto dto)
    {
        return await GetEntityById(dto.Id);
    }

    public UserDto DtoFrom(User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Username = entity.Username
        };
    }

    public async Task<UserDto> RemoveById(int id)
    {
        var entity = GetEntityById(id);
        var removedEntity = _context.Remove(await entity).Entity;
        await _context.SaveChangesAsync();
        return DtoFrom(removedEntity);
    }

    public async Task<IList<User>> GetAllEntities()
    {
        return await _context.Users.ToListAsync();
    }
}