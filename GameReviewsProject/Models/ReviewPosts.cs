using System;
using System.ComponentModel.DataAnnotations;

namespace GameReviewSolution.Models;

public class ReviewPost
{
    private int _rating;
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public User Author { get; set; }
    [MaxLength] public string ReviewText { get; set; }

    public int Rating
        // rating is 1 through 5
    {
        get => _rating;
        set
        {
            if (value is > 5 or < 0) throw new ArgumentOutOfRangeException(nameof(value));
            _rating = value;
        }
    }
}