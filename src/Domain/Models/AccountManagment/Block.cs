using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AccountManagment
{
    public class Block
    {
        public int Id;
        public string blockId;

        public string name;
        public string postalCode;
        public int floors;
    }
}