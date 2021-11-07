using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewSolution.Models
{
    [Table("StreetAddresses")]

    public class StreetAddress
    {
        public string Id { get; set; }
        
        public string FirstLine { get; set; }
        public string? SecondLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}