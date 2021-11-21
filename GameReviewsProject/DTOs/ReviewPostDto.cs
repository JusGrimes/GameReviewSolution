using GameReviewSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameReviewSolution.DTOs;

internal class ReviewPostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserDto Author { get; set; }
    public string ReviewText { get; set; }
    
    public static ReviewPostDto FromEntity(ReviewPost post)
    {
        return new ReviewPostDto
        {
            Id = post.Id,
            UserId = post.UserId,
            Author = UserDto.FromEntity(post.Author),
            ReviewText = post.ReviewText
        };
    }
}