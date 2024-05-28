namespace Domain.Entities
{
    public class Residence
    {
        public int Id;
        public string ResidenceId { get; set; } = null!;

        public string Street { get; set; } = null!;
        public string BuildingNumber { get; set; } = null!;
        public string ApartmentNumber { get; set; } = null!;
        public int Floor { get; set; }

        public string BlockId { get; set; } = null!;
        public Block Block { get; set; } = null!;
    }
}