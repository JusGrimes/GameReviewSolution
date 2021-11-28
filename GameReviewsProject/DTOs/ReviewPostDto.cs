using GameReviewSolution.Models;

namespace GameReviewSolution.DTOs;

public class ReviewPostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public GameDto Game { get; set; }
    public UserDto Author { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }

    public static ReviewPostDto FromEntity(ReviewPost post)
    {
        return new ReviewPostDto
        {
            Id = post.Id,
            UserId = post.UserId,
            Game = null,
            Author = UserDto.FromEntity(post.Author),
            Rating = post.Rating,
            ReviewText = post.ReviewText
        };
    }
    // TODO refactor to use Service
}