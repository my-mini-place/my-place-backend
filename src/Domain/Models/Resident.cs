 using Domain.Models.Identity;

namespace Domain.Entities
{
    public class Resident
    {
        public int Id { get; set; }
        public string Guid { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public Residence Residence { get; set; } = null!;
        public string ResidenceId { get; set; } = null!;
    }
}