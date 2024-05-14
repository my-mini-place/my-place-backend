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
        public string BlockId { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int floors;
    }
}