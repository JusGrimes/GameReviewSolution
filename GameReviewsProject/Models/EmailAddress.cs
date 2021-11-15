using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewSolution.Models;

[Table("EmailAddresses")]
public class EmailAddress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User Owner { get; set; }
    public string EmailAddressUri { get; set; }
}