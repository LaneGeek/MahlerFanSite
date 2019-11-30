using System;
using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public class Story
    {
        private List<Comment> _comments = new List<Comment>();
        private List<Rating> _ratings = new List<Rating>();
        
        public int StoryId { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments => _comments;
        public List<Rating> Ratings => _ratings;

        public void AddComment(Comment comment) => Comments.Add(comment);
        public void AddRating(Rating rating) => Ratings.Add(rating);
    }
}
