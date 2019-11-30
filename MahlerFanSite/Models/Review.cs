using System;

namespace MahlerFanSite.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public User Reviewer { get; set; }
        public DateTime ReviewDate { get; set; }
        public Story ReviewStory { get; set; }
    }
}
