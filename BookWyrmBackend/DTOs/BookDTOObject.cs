using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWyrmBackend.DTOs
{
    public class BookDTOObject
    {
        public string Title { get; set; }
        public string[] Author { get; set; }

        public string Description { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
