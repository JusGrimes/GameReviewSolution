using System;
using System.Collections.Generic;

namespace GameReviewSolution.Models
{
    public class Game
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Publisher GamePublisher { get; set; }
        public List<ReviewPost> ReviewsPosts { get; set; }
    }
}