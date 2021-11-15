using System;

namespace GameReviewSolution.Models;

public class User
{
    private DateTime _dateOfBirth;
    public int Id { get; set; }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set => _dateOfBirth = value.Date;
    }

    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmailAddress UserEmailAddress { get; set; }
    public StreetAddress MailingAddress { get; set; }
}