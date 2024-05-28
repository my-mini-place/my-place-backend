using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO.Blocks
{
    

    public class BlockDTO
    {
        public string BlockId { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? PostalCode { get; set; } = null!;
        public int? Floors { get; set; }
    }


}
