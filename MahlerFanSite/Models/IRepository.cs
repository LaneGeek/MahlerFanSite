using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public interface IRepository
    {
        List<Story> Stories { get;}

        void AddStory(Story story);

        void AddComment(Story story, Comment comment);

        void AddRating(Story story, Rating rating);

        Story GetStoryByText(string text);
    }
}
