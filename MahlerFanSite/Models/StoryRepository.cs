using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MahlerFanSite.Models
{
    public class StoryRepository : IRepository
    {
        private AppDbContext context;

        public List<Story> Stories => context.Stories.Include("Comments").Include("Ratings").ToList();

        public void AddStory(Story story)
        {
            context.Stories.Add(story);
            context.SaveChanges();
        }

        public void AddComment(Story story, Comment comment)
        {
            story.Comments.Add(comment);
            context.Stories.Update(story);
            context.SaveChanges();
        }

        public void AddRating(Story story, Rating rating)
        {
            story.Ratings.Add(rating);
            context.Stories.Update(story);
            context.SaveChanges();
        }

        public Story GetStoryByText(string text) => context.Stories.First(x => x.Text == text);

        public StoryRepository(AppDbContext context) => this.context = context;
    }
}
