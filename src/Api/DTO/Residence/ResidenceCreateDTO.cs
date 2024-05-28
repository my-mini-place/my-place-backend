using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
