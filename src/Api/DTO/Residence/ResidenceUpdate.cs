using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO.Residence
{
    public class ResidenceUpdate
    {
     //   public string ResidenceId { get; set; } = null!;

        public string? Street { get; set; } = null!;
        public string? BuildingNumber { get; set; } = null!;
        public string? ApartmentNumber { get; set; } = null!;
        public int? Floor { get; set; }
    }
}
