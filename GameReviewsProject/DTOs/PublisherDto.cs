using GameReviewSolution.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace GameReviewSolution.DTOs;

public class PublisherDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string WebsiteUri { get; set; }

    public static PublisherDto FromEntity(Publisher publisher)
    {
        return new PublisherDto
        {
            Id = publisher.Id,
            Name = publisher.Name,
            WebsiteUri = publisher.WebsiteUri
        };
    }
}