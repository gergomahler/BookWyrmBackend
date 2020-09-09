using BookWyrmBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWyrmBackend
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BookWyrmBackend.Models.BookHoard> BookHoards { get; set; }

        public DbSet<BookWyrmBackend.Models.Book> Books { get; set; }
    }
}
