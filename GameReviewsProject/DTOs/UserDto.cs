using GameReviewSolution.Models;

namespace GameReviewSolution.DTOs;

internal class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }

    public static UserDto FromEntity(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username
        };
    }
}