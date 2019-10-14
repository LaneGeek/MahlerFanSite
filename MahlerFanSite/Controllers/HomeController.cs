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
            if (StoryRepository.Stories.Count == 0)
            {
                Story story = new Story()
                {
                    StoryId = 1,
                    Text = "Mahler once slept the whole day!",
                    PublishedDate = new DateTime(2012, 6, 12)
                };
                StoryRepository.AddStory(story);
            }
        }

        public IActionResult Index() => View();

        public IActionResult History() => View();

        public IActionResult Stories()
        {
            List<Story> stories = StoryRepository.Stories;
            return View(stories);
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
