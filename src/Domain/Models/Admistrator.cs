using Domain.Models.Identity;

namespace Domain.Entities
{
    public class Administrator
    {
        public int Id;
        public string Guid { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}