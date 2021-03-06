using System;
using System.Text.Json.Serialization;

namespace GameReviewSolution.DTOs;

public class GameDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("game_uri")] public string GameWebsiteUri { get; set; }

    [JsonPropertyName("Publisher")] public string PublisherName { get; set; }

    [JsonPropertyName("publisher_uri")] public string PublisherWebsiteUri { get; set; }
}