using System;
using System.Collections.Generic;
using System.Web;
using MahlerFanSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository) => this._repository = repository;
        
        public IActionResult Index()
        {
            // Using ViewBag to send today's date
            String today = DateTime.Today.ToString("D");
            ViewBag.Date = today;
            return View();
        }

        public IActionResult History() => View();

        public IActionResult Stories()
        {
            List<Story> stories = _repository.Stories;
            stories.Sort((a, b) => string.Compare(a.Text, b.Text, StringComparison.Ordinal));
            return View("Stories", stories);
        }

        public IActionResult AddStory() => View();

        [HttpPost]
        public RedirectToActionResult AddStory(string text, string pubDate)
        {
            ViewBag.FormType = "Add a story";
            Story story = new Story
            {
                Text = text,
                PublishedDate = DateTime.Parse(pubDate)
            };
            _repository.AddStory(story);
            return RedirectToAction("Stories");
        }

        public IActionResult AddComment(string storyText) => View("AddComment", HttpUtility.HtmlDecode(storyText));

        [HttpPost]
        public RedirectToActionResult AddComment(string storyText, string text, string name)
        {
            Comment comment = new Comment {Text = text, Name = name};
            Story story = _repository.GetStoryByText(storyText);
            story.AddComment(comment);
            return RedirectToAction("Stories");
        }

        public IActionResult AddRating(string storyText) => View("AddRating", HttpUtility.HtmlDecode(storyText));

        [HttpPost]
        public RedirectToActionResult AddRating(string storyText, string rating)
        {
            Story story = _repository.GetStoryByText(storyText);
            story.AddRating(Int32.Parse(rating));
            return RedirectToAction("Stories");
        }
    }
}
