using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public interface IRepository
    {
        List<Story> Stories { get;}

        void AddStory(Story story);

        Story GetStoryByText(string text);
    }
}
