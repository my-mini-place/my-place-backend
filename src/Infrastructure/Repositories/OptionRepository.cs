using Api.Interfaces.IRepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OptionRepository : Repository<Option>, IOptionRepository
    {
        public OptionRepository(ApplicationDbContext db) : base(db)
        {
        }

       
    }
}