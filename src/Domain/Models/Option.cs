namespace Domain.Models
{
    public class Option
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid PostId { get; set; }
        public List<Vote> Votes { get; set; }
    }
}