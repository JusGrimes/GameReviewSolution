using GameReviewSolution.Models;

namespace GameReviewSolution.DTOs;

public class ReviewPostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User Author { get; set; }
    public string ReviewText { get; set; }

    public static ReviewPostDto FromEntity(ReviewPost post)
    {
        return new ()
        {
            Id = post.Id,
            UserId = post.UserId,
            Author = post.Author,
            ReviewText = post.ReviewText
        };
    }
}