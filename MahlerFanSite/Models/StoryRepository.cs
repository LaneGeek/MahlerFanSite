using System;
using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public class StoryRepository : IRepository
    {
        // TODO: Replace this with a proper database

        private static List<Story> _stories = new List<Story>();

        public List<Story> Stories => _stories;

        public void AddStory(Story story) => Stories.Add(story);

        public Story GetStoryByText(string text) => _stories.Find(x => x.Text == text);

        public StoryRepository()
        {
            if (_stories.IsEmpty())
            {
                // If the repository is empty lets add three stories
                _stories.Add(new Story
                {
                    StoryId = 1,
                    Text = "Mahler once slept the whole day!",
                    PublishedDate = new DateTime(2012, 6, 12),
                    Ratings = {4, 0, 5, 1},
                    Comments =
                    {
                        new Comment {Text = "Good story", Name = "Taylor"},
                        new Comment {Text = "Crappy story", Name = "David"}
                    }
                });
                _stories.Add(new Story
                {
                    StoryId = 2,
                    Text = "I met Mahler once!",
                    PublishedDate = new DateTime(2002, 6, 12)
                });

                _stories.Add(new Story
                {
                    StoryId = 3,
                    Text = "Once upon a time...",
                    PublishedDate = new DateTime(2012, 11, 12),
                    Ratings = { 0, 0, 5 },
                    Comments =
                    {
                        new Comment {Text = "Sad story", Name = "John"},
                        new Comment {Text = "Fake story!", Name = "Donald"}
                    }
                });
            }
        }
    }
}
