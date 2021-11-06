namespace GameReviewSolution.Models
{
    public class ContactInformation
    {
        public User Owner { get; set; }
        public EmailAddress PrimaryEmailAddress { get; set; }
        public Address HomeAddress { get; set; }
    }
}