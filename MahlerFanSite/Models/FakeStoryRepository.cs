using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public class FakeStoryRepository : IRepository
    {
        private static List<Story> _stories = new List<Story>();

        public List<Story> Stories => _stories;

        public void AddStory(Story story) => Stories.Add(story);

        public void AddComment(Story story, Comment comment) { }

        public void AddRating(Story story, Rating rating) { }

        public Story GetStoryByText(string text) => _stories.Find(x => x.Text == text);
    }
}
