using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Block
    {
        public int Id;
        public string BlockId;

        public string Name;
        public string PostalCode;
        public int floors;
    }
}