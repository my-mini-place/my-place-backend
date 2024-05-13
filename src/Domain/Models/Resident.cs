using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Resident
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Residence Residence { get; set; }
        public string ResidenceId { get; set; }
    }
}