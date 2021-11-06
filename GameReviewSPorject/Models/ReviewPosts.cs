namespace GameReviewSolution.Models
{
    public class ReviewPosts
    {
        private int _rating;

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