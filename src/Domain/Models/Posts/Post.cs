namespace Domain.Models.Posts
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}