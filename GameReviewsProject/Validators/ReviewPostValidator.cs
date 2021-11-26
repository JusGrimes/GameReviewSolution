using FluentValidation;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;

namespace GameReviewSolution.Validators;

public class ReviewPostValidator : AbstractValidator<ReviewPostDto>
{
    public ReviewPostValidator(IValidator<GameDtoValidator> gameValidator, IValidator<User> userValidator)
    {
        RuleFor(dto => dto.Rating).InclusiveBetween(1, 5);

    }
}