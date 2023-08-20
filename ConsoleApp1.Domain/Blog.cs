namespace ConsoleApp1.Domain
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; } = null!;
        public int Rating { get; set; }
        public List<Post> Posts { get; set; } = null!;
    }
}