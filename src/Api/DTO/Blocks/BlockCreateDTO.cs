using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO.Blocks
{
    public class BlockCreateDTO
    { 
      
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public int floors { get; set; }
    }
}
