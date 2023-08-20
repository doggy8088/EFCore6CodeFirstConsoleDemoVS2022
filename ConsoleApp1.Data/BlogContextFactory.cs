using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleApp1.Data;

public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
{
    public BlogContext CreateDbContext(string[] args)
    {
        return new BlogContext();
    }
}
