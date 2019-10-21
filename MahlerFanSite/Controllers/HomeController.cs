using System;
using System.Collections.Generic;
using System.Web;
using MahlerFanSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            // Some stories to fill our repository for testing
            if (StoryRepository.Stories.IsEmpty())
            {
                Story story = new Story
                {
                    StoryId = 1,
                    Text = "Mahler once slept the whole day!",
                    PublishedDate = new DateTime(2012, 6, 12)
                };
                story.AddRating(4);
                StoryRepository.AddStory(story);
                story = new Story
                {
                    StoryId = 2,
                    Text = "I met Mahler once!",
                    PublishedDate = new DateTime(2002, 6, 12)
                };
                StoryRepository.AddStory(story);
                story = new Story
                {
                    StoryId = 3,
                    Text = "Once upon a time...",
                    PublishedDate = new DateTime(2012, 11, 12)
                };
                story.AddComment(new Comment {Text = "Sad story :(", Name = "John"});
                story.AddComment(new Comment {Text = "Fake story! Sad!", Name = "Donald"});
                story.AddRating(5);
                story.AddRating(0);
                StoryRepository.AddStory(story);
            }
        }

        public IActionResult Index() => View();

        public IActionResult History() => View();

        public IActionResult Stories()
        {
            List<Story> stories = StoryRepository.Stories;

            // Stories are now sorted alphabetically by the text of the story
            stories.Sort((a, b) => string.Compare(a.Text, b.Text, StringComparison.Ordinal));

            return View("Stories", stories);
        }

        public IActionResult AddStory() => View();

        [HttpPost]
        public RedirectToActionResult AddStory(string text, string pubDate, string storyId)
        {
            Story story = new Story
            {
                Text = text,
                PublishedDate = DateTime.Parse(pubDate),
                StoryId = Int32.Parse(storyId)
            };
            StoryRepository.AddStory(story);
            return RedirectToAction("Stories");
        }

        public IActionResult AddComment(string storyText) => View("AddComment", HttpUtility.HtmlDecode(storyText));

        [HttpPost]
        public RedirectToActionResult AddComment(string storyText, string text, string name)
        {
            Comment comment = new Comment {Text = text, Name = name};
            Story story = StoryRepository.GetStoryByText(storyText);
            story.AddComment(comment);
            return RedirectToAction("Stories");
        }

        public IActionResult AddRating(string storyText) => View("AddRating", HttpUtility.HtmlDecode(storyText));

        [HttpPost]
        public RedirectToActionResult AddRating(string storyText, string rating)
        {
            Story story = StoryRepository.GetStoryByText(storyText);
            story.AddRating(Int32.Parse(rating));
            return RedirectToAction("Stories");
        }
    }
}
