using FluentValidation;
using GameReviewSolution.DTOs;
using GameReviewSolution.Validators.Helpers;

namespace GameReviewSolution.Validators;

public class GameDtoValidator : AbstractValidator<GameDto>
{
    public GameDtoValidator()
    {
        RuleFor(dto => dto.Title).NotEmpty();
        RuleFor(dto => dto.PublisherWebsiteUri).Must(UriHelper.IsValidUri);
        RuleFor(dto => dto.PublisherWebsiteUri).Must(UriHelper.IsValidUri);
        RuleFor(dto => dto.PublisherName).NotEmpty();
    }
}