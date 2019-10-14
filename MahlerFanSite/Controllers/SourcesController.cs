using System;
using System.Collections.Generic;
using MahlerFanSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class SourcesController : Controller
    {
        public SourcesController()
        {
            if (BookRepository.Books.Count == 0)
            {
                Book book = new Book()
                {
                    BookId = 1,
                    Title = "Mahler Rocks!",
                    PublishedDate = new DateTime(2012, 6, 12)
                };
                BookRepository.AddBook(book);
            }
        }
        
        public IActionResult Index() => View();

        public IActionResult Books()
        {
            List<Book> books = BookRepository.Books;
            return View(books);
        }

        public IActionResult Links() => View();
        
        public IActionResult AddBook() => View();

        [HttpPost]
        public RedirectToActionResult AddBook(string title, string pubDate, string bookId)
        {
            Book book = new Book()
            {
                Title = title,
                PublishedDate = DateTime.Parse(pubDate),
                BookId = Int32.Parse(bookId)
            };
            BookRepository.AddBook(book);
            return RedirectToAction("Books");
        }
    }
}
