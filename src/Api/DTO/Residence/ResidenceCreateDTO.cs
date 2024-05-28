using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Residence
{
    public class ResidenceCreateDTO
    {
        [Required]
        public string Street { get; set; } = null!;

        [Required]
        public string BuildingNumber { get; set; } = null!;

        [Required]
        public string ApartmentNumber { get; set; } = null!;

        [Required]
        public int Floor { get; set; }

        [Required]
        public string BlokId { get; set; }
    }
}