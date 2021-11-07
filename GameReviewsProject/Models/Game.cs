using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewSolution.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        
        [Column("Publisher")] public Publisher GamePublisher { get; set; }
        public List<ReviewPost> ReviewsPosts { get; set; }
    }
}