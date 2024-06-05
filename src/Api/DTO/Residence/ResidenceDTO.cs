namespace Api.DTO.Residence
{
    public class ResidenceDTO
    {
        public string ResidenceId { get; set; } = null!;

        public string Street { get; set; } = null!;
        public string BuildingNumber { get; set; } = null!;
        public string ApartmentNumber { get; set; } = null!;
        public int Floor { get; set; }
    }
}