﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahlerFanSite.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
        public User Author { get; set; }
    }
}
