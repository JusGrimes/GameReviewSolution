using FluentValidation;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;

namespace GameReviewSolution.Validators;

public class ReviewPostValidator : AbstractValidator<ReviewPostDto>
{
    public ReviewPostValidator(IValidator<GameDto> gameValidator)
    {
        RuleFor(dto => dto.Rating).InclusiveBetween(1, 5);
    }
}