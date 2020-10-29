﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookWyrmBackend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
