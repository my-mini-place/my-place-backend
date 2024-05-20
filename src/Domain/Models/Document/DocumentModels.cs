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
            
            public string pdfFile { get; set; }
        }

    }
}
