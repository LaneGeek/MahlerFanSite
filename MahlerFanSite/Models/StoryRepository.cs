using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MahlerFanSite.Models
{
    public class StoryRepository : IRepository
    {
        private AppDbContext context;

        public List<Story> Stories => context.Stories.Include("Comments").ToList();

        public void AddStory(Story story)
        {
            context.Stories.Add(story);
            context.SaveChanges();
        }

        public Story GetStoryByText(string text) => context.Stories.First(x => x.Text == text);

        public StoryRepository(AppDbContext context) => this.context = context;
    }
}
