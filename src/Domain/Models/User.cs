using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        // public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public string Role { get; set; }
        public string Email { get; set; }
        public AccountStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}