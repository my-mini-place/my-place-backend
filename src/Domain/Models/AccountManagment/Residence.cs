using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AccountManagment
{
    public class Residence
    {
        public int Id;
        public string ResidenceId;
        public string PostalCode { get; set; }

        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int Floor { get; set; }
    }
}