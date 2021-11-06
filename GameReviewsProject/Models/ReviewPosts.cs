namespace GameReviewSolution.Models
{
    public class ReviewPost
    {
        private int _rating;
        public string ReviewText { get; set; }
        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value switch
                {
                    < 1 => 1,
                    > 5 => 5,
                    _ => value
                };
            }
        }

    }
}