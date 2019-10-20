using System;
using System.Collections.Generic;
using MahlerFanSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            // Some stories to fill our repository for testing
            if (StoryRepository.Stories.Count == 0)
            {
                Story story = new Story()
                {
                    StoryId = 1,
                    Text = "Mahler once slept the whole day!",
                    PublishedDate = new DateTime(2012, 6, 12)
                };
                StoryRepository.AddStory(story);
                story = new Story()
                {
                    StoryId = 2,
                    Text = "I met Mahler once!",
                    PublishedDate = new DateTime(2002, 6, 12)
                };
                StoryRepository.AddStory(story);
                story = new Story()
                {
                    StoryId = 3,
                    Text = "Once upon a tie...",
                    PublishedDate = new DateTime(2012, 11, 12)
                };
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
            Story story = new Story()
            {
                Text = text,
                PublishedDate = DateTime.Parse(pubDate),
                StoryId = Int32.Parse(storyId)
            };
            StoryRepository.AddStory(story);
            return RedirectToAction("Stories");
        }
    }
}
