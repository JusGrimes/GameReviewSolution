// ReSharper disable UnusedAutoPropertyAccessor.Global

#pragma warning disable CS8632
namespace GameReviewSolution.Models;

public class StreetAddress
{
    public int Id { get; set; }
    public string FirstLine { get; set; }
    public string? SecondLine { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zipcode { get; set; }
}