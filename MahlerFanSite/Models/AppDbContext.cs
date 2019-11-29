using Microsoft.EntityFrameworkCore;

namespace MahlerFanSite.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
