using Domain.Models.Identity;

namespace Domain.Entities
{
    public class Manager
    {
        public int Id;
        public string Guid { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public TimeSpan StartWorkTime { get; set; }
        public TimeSpan EndWorkTime { get; set; }
    }
}