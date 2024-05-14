using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO.AccountManagment
{
    public class AccountStatusUpdateDTO
    {
        public AccountStatus AccountStatus { get; set; }
        public string? NewRole { get; set; }
    }
}