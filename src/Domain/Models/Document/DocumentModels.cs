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
using static Domain.Calendar;
using static Domain.Models.Calendar.CalendarModels;

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
            public Document()
            {
                DocumentId = 100;
                description = "auto descrition";
            }
            public Document(Document doc)
            {
                DocumentId = doc.DocumentId;
                content = doc.content;
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
            public Document(DocumentDto doc)
            {
                DocumentId = doc.DocumentId;
                content = doc.content;
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
        }

        public class DocumentDto
        {
            [Key]
            public int DocumentId { get; set; }
            public string content { get; set; }
            public string name { get; set; }
            public bool signed { get; set; }
            public string description { get; set; }
            public DateTime creation_date { get; set; }

            public DocumentDto()    
            {
                DocumentId = 100;
                description = "auto descrition";
            }
            public DocumentDto(DocumentDto doc)
            {
                DocumentId = doc.DocumentId;
                content = doc.content;
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
            public DocumentDto(Document doc) {
                DocumentId = doc.DocumentId;
                content = doc.content;
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
        }


        public static class DocumentMapper
        {
            public static Document castDtoDocumentToDocument(DocumentDto docDto)
            {
                Document doc = new Document(docDto);
                return doc;
            }

        }
    }
}

