﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahlerFanSite.Models
{
    public static class BookRepository
    {
        private static List<Book> _books = new List<Book>();

        public static List<Book> Books => _books;

        public static void AddBook(Book book) => Books.Add(book);
    }
}
