using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public static class StoryRepository
    {
        private static List<Story> _stories = new List<Story>();

        public static List<Story> Stories => _stories;

        public static void AddStory(Story story) => Stories.Add(story);
    }
}
