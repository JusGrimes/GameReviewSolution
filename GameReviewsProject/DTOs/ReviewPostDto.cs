namespace GameReviewSolution.DTOs;

public class ReviewPostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public int GameId { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
}