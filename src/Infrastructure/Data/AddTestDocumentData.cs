using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Document.DocumentModels;

namespace Infrastructure.Data
{
    public static class AddTestDocumentData
    {
        public static void addTestDocumentData(this ModelBuilder modelBuilder)
        {

            Guid ManagerGuid = Guid.NewGuid();

            Document sampleEvent = new Document
            {
                DocumentId = 10,
                pdfFile = "Lorem Ipsum. Laudetur Iesus Christus!"
            };

            modelBuilder.Entity<Document>().HasData(sampleEvent);
        }
    }
}
