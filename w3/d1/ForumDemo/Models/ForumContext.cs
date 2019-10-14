using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions options) : base(options) { }
        // DBSet prop name will be used as table names in DB
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}