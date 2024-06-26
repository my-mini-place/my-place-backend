﻿using Domain.Entities;
using Domain.Models.Identity;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
    }
}
