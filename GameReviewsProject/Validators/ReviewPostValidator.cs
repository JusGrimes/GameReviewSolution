using FluentValidation;
using GameReviewSolution.DTOs;

namespace GameReviewSolution.Validators;

public class ReviewPostValidator : AbstractValidator<ReviewPostDto>
{
    public ReviewPostValidator(IValidator<GameDto> gameValidator)
    {
        RuleFor(dto => dto.Rating).InclusiveBetween(1, 5);
    }
}