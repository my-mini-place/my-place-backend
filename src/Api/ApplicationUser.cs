using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
    }
}