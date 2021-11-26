using System;
using FluentValidation;
using GameReviewSolution.DTOs;

namespace GameReviewSolution.Validators;

public class GameDtoValidator : AbstractValidator<GameDto>
{
    public GameDtoValidator()
    {
        RuleFor(dto => dto.PublisherWebsiteUri).Must(ValidateUri);
        RuleFor(dto => dto.PublisherWebsiteUri).Must(ValidateUri);
    }

    public bool ValidateUri(string uri)
    {
        return Uri.TryCreate(uri, UriKind.Absolute, out var uriCreated)
               && (
                   uriCreated.Scheme == Uri.UriSchemeHttp ||
                   uriCreated.Scheme == Uri.UriSchemeHttps);
    }
}