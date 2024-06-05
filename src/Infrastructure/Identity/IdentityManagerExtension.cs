using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace Infrastructure.Identity
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByUserIdCustomAsync(this UserManager<ApplicationUser> um, string userId)
        {
            return await um?.Users?.SingleOrDefaultAsync(x => x.UserId ==userId);
        }

        
    }
}
