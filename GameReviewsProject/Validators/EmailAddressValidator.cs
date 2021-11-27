using FluentValidation;
using GameReviewSolution.Models;

namespace GameReviewSolution.Validators;

public class EmailAddressValidator : AbstractValidator<EmailAddress>
{
    public EmailAddressValidator()
    {
        RuleFor(email => email.EmailAddressUri).EmailAddress();
    }
}