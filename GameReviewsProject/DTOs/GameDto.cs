using System;
using System.Text.Json.Serialization;
using GameReviewSolution.Models;

namespace GameReviewSolution.DTOs;

internal class GameDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("game_uri")] public string GameWebsiteUri { get; set; }

    [JsonPropertyName("Publisher")] public string PublisherName { get; set; }

    [JsonPropertyName("publisher_uri")] public string PublisherWebsiteUri { get; set; }

    public static GameDto FromEntity(Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            ReleaseDate = game.ReleaseDate,
            GameWebsiteUri = game.GameUri,
            PublisherName = game.GamePublisher.Name,
            PublisherWebsiteUri = game.GamePublisher.WebsiteUri
        };
    }
}