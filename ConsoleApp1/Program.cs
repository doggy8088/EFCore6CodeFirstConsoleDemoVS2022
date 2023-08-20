using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Data;
using ConsoleApp1.Domain;

var blog = CreateBlog();
Console.WriteLine("Blog created");
Console.WriteLine(blog.Dump());

Console.WriteLine("--------------------------------");

var blogs = ListBlogs();
Console.WriteLine("List all blogs below:");
foreach (var item in blogs)
{
    Console.WriteLine(item.Dump());
    Console.WriteLine();
}

Console.WriteLine("--------------------------------");

var blogUpdated = UpdateBlogRating(blogId: blog.BlogId, rating: 4);
Console.WriteLine("Blog updated");
Console.WriteLine(blogUpdated.Dump());

Console.WriteLine("--------------------------------");

var blogDeleted = DeleteBlog(blogId: blog.BlogId);
Console.WriteLine("Blog deleted");
Console.WriteLine(blogDeleted.Dump());

static Blog CreateBlog()
{
    using var db = new BlogContext();
    var blog = new Blog()
    {
        Rating = 5,
        Url = "https://www.miniasp.com"
    };
    db.Blogs.Add(blog);
    db.SaveChanges();

    return blog;
}

static List<Blog> ListBlogs()
{
    using var db = new BlogContext();
    return db.Blogs.ToList();
}

static Blog? UpdateBlogRating(int blogId, int rating)
{
    using var db = new BlogContext();
    var blog = db.Blogs.Find(blogId);
    if (blog != null)
    {
        blog.Rating = rating;
        db.SaveChanges();
        return blog;
    }
    else
    {
        return null;
    }
}

static Blog? DeleteBlog(int blogId)
{
    using var db = new BlogContext();
    var blog = db.Blogs.Find(blogId);
    if (blog != null)
    {
        db.Blogs.Remove(blog);
        db.SaveChanges();
        return blog;
    }
    else
    {
        return null;
    }
}