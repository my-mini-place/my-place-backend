namespace Domain.Models.Posts
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int OptionId { get; set; }    
        public string UserId { get; set; }
    }
}