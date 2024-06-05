namespace Domain.Models
{
    public class Vote
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid OptionId { get; set; }
        public Guid UserId { get; set; }

    }
}