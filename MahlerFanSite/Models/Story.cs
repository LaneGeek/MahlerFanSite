using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahlerFanSite.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; }
        public List<int> Ratings { get; }

        public Story()
        {
            Comments = new List<Comment>();
            Ratings = new List<int>();
        }

        public void AddComment(Comment comment) => Comments.Add(comment);
        public void AddRating(int rating) => Ratings.Add(rating);
    }
}
