using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookWyrmBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<BookHoard> BookHoards { get; set; }
        public List<Author> FavAuthors { get; set; }
        public List<Publisher> FavPublishers { get; set; }
        public List<Genre> GenPrefs { get; set; }
        public string AuthToken { get; set; }

        internal string GenerateAuthToken()
        {
            string toHash = Username + Password + Stopwatch.GetTimestamp().ToString();
            return toHash.GetHashCode().ToString();
        }
    }
}
