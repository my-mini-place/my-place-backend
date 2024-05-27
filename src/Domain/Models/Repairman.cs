using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Repairman
    {
        public int Id;

        public string Guid { get; set;  } = null!;

        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public TimeSpan StartWorkTime { get; set; }
        public TimeSpan EndWorkTime { get; set; }
    }
}