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
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;


namespace Domain.Models.Document
{
    public class DocumentModels
    {
        public static Document CreateDocument(int documentId, string text, string name, int _UserId)
        {

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = name;

            PdfPage pdfPage = pdf.AddPage();

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

           // XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
          //  graph.DrawString(text, font, XBrushes.Black, new XRect(0, 0, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);

            // Save the document to a MemoryStream
            using (MemoryStream stream = new MemoryStream())
            {
                pdf.Save(stream, false);
                return new Document
                {
                    DocumentId = documentId,
                    UserId = _UserId,
                    content = stream.ToArray(),
                    name = name,
                    signed = false,
                    description = "Generated PDF Document",
                    creation_date = DateTime.Now
                };
            }

        }

        public static byte[] ConvertStringToByteArray(string str)
        {
            Encoding encoding = Encoding.UTF8;

            byte[] byteArray = encoding.GetBytes(str);

            return byteArray;
        }

        public static string ConvertByteArrayToString(byte[] byteArray)
        {
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(byteArray);
        }

        public class Document
        {
            [Key]
            public int DocumentId { get; set; }
            public int UserId { get; set; }
            public byte[] content { get; set; }
            public string  name {  get; set; }
            public bool signed { get; set; }
            public string description { get; set; }
            public DateTime creation_date { get; set; }
            public Document()
            {
                DocumentId = 100;
                UserId = -1;
                description = "auto descrition";
            }
            public Document(Document doc)
            {
                DocumentId = doc.DocumentId;
                content = doc.content;
                UserId = doc.UserId;
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
            public Document(DocumentDto doc)
            {
                UserId = doc.UserId;
                DocumentId = doc.DocumentId;
                content = ConvertStringToByteArray(doc.content);
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
        }

        // Różnicą główną między Document, a DocumentDto jest inny typ dla zmiennej content. Content w DocumentDto jest stringiem.
        public class DocumentDto
        {
            [Key]
            public int DocumentId { get; set; }
            public int UserId { get; set; }
            public string content { get; set; }
            public string name { get; set; }
            public bool signed { get; set; }
            public string description { get; set; }
            public DateTime creation_date { get; set; }

            public DocumentDto()    
            {
                DocumentId = 100;
                UserId = -1;
                description = "auto descrition";
            }
            public DocumentDto(DocumentDto doc)
            {
                DocumentId = doc.DocumentId;
                UserId = doc.UserId;
                content = doc.content;
                name = doc.name;
                signed = doc.signed;
                description = doc.description;
                creation_date = doc.creation_date;
            }
            public DocumentDto(Document doc) {
                DocumentId = doc.DocumentId;
                UserId = doc.UserId;
                content = ConvertByteArrayToString(doc.content);
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

            public static DocumentDto castDocumentToDtoDocument(Document doc)
            {
                DocumentDto docDto = new DocumentDto(doc);
                return docDto;
            }
        }
    }
}

