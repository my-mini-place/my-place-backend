using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Document
{
    public class DocumentModels
    {
        public class Document
        {
            [Key]
            public int DocumentId { get; set; }   
            public string content { get; set; }
            public string  name {  get; set; }
            public bool signed { get; set; }
            public string description { get; set; }
            public DateTime creation_date { get; set; }

        }

    }
}
