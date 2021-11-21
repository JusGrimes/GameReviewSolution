using System.ComponentModel.DataAnnotations;

namespace GameReviewSolution.Models;

public class ReviewPost
{
    private int _rating;
    public int UserId { get; set; }
    public User Author { get; set; }
    public int Id { get; set; }
    [MaxLength] public string ReviewText { get; set; }

    public int Rating
        // rating is 1 through 5
    {
        get => _rating;
        set
        {
            _rating = value switch
            {
                < 1 => 1,
                > 5 => 5,
                _ => value
            };
        }
    }
}