using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookWyrmBackend.Models
{
    public class BookHoard
    {
        public BookHoard()
        {
            Hoard = new List<Book>();
        }

        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public List<Book> Hoard { get; set; }

    }
}
