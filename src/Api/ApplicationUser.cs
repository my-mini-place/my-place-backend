using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string UserId { get; set; }
    }
}