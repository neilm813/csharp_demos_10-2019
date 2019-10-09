using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
    }
}