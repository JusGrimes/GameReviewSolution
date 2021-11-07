using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewSolution.Models
{
    [Table("Publishers")]

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUri { get; set; }
    }
}