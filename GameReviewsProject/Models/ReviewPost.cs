using System.ComponentModel.DataAnnotations;

namespace GameReviewSolution.Models;

public class ReviewPost
{
    public int Id { get; set; }
    public Game Game { get; set; }
    public User Author { get; set; }
    [MaxLength] public string ReviewText { get; set; }
    public int Rating { get; set; }
}