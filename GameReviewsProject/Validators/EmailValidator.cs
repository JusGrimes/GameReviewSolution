using FluentValidation;
using GameReviewSolution.Models;

namespace GameReviewSolution.Validators;

public class EmailValidator : AbstractValidator<EmailAddress>
{
    public EmailValidator()
    {
        RuleFor(email => email.EmailAddressUri).EmailAddress();
    }
}