// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8632
namespace GameReviewSolution.Models;

public class StreetAddress
{
    public StreetAddress(string firstLine, string? secondLine, string city, string state, int zipcode)
    {
        FirstLine = firstLine;
        SecondLine = secondLine;
        City = city;
        State = state;
        Zipcode = zipcode;
    }

    public string Id { get; set; } = null!;
    public string FirstLine { get; set; }
    public string? SecondLine { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zipcode { get; set; }
}