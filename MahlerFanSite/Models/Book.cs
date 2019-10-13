using System;
using System.Collections.Generic;

namespace MahlerFanSite.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<Author> Authors { get; }
        public List<Review> Reviews { get; }

        public Book()
        {
            Authors = new List<Author>();
            Reviews = new List<Review>();
        }
    }
}
