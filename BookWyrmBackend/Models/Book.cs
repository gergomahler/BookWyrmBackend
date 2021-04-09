using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookWyrmBackend.Models
{
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid().ToString();
            BuyLinks = new List<string>();
            Genres = new List<Genre>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author[] Author { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> BuyLinks { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
