using ConsoleApp1.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext() {}
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Blog;Trusted_Connection=True;");
        }

        public DbSet<Blog> Blogs { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
    }
}