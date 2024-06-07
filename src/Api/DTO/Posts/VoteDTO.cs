using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO.Posts
{
    public class VoteDTO
    {
       
        public Guid PostId { get; set; }
        public Guid OptionId { get; set; }
        public Guid UserId { get; set; }

    }
}
