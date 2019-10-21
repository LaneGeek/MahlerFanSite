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
            // Some books to fill our repository for testing
            if (BookRepository.IsEmpty)
            {
                Book book = new Book
                {
                    BookId = 1,
                    Title = "Mahler Rocks!",
                    PublishedDate = new DateTime(2012, 6, 12)
                };
                BookRepository.AddBook(book);
                book = new Book
                {
                    BookId = 2,
                    Title = "Life of Mahler",
                    PublishedDate = new DateTime(2002, 6, 12)
                };
                BookRepository.AddBook(book);
                book = new Book
                {
                    BookId = 2,
                    Title = "Son of Mahler",
                    PublishedDate = new DateTime(2002, 6, 5)
                };
                BookRepository.AddBook(book);
            }

            // Some links to fill our repository for testing
            if (LinkRepository.IsEmpty)
            {
                Link link = new Link
                {
                    LinkId = 1,
                    Description = "Wikipedia page about Mahler",
                    Url = "https://en.wikipedia.org/wiki/Gustav_Mahler"
                };
                LinkRepository.AddLink(link);
                link = new Link
                {
                    LinkId = 2,
                    Description = "Mahler's list of compositions",
                    Url = "https://en.wikipedia.org/wiki/List_of_compositions_by_Gustav_Mahler"
                };
                LinkRepository.AddLink(link);
                link = new Link
                {
                    LinkId = 3,
                    Description = "15 Facts",
                    Url = "https://www.classicfm.com/composers/mahler/pictures/mahlers-150th-birthday/"
                };
                LinkRepository.AddLink(link);
            }
        }
        
        public IActionResult Index() => View();

        public IActionResult Books()
        {
            List<Book> books = BookRepository.Books;

            // Books are now sorted alphabetically by the title
            books.Sort((a, b) => string.Compare(a.Title, b.Title, StringComparison.Ordinal));

            return View("Books", books);
        }

        public IActionResult Links()
        {
            List<Link> links = LinkRepository.Links;

            // Links are now sorted alphabetically by the description
            links.Sort((a, b) => string.Compare(a.Description, b.Description, StringComparison.Ordinal));

            return View("Links", links);
        }
        
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
