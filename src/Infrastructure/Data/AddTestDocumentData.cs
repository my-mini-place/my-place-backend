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
                name = "Organizacja pikniku",
                content = "Plik formatu pdf: Prosimy o wyrażenie zgody o zorganizowanie wydarzenia",
                signed = false,
                description = "Pozwolenie na zorganizowanie pikniku",
                creation_date = new DateTime(2024,4,7)
            };

            Document sampleEvent2 = new Document
            {
                DocumentId = 15,
                name = "Wymiana drzwi",
                content = "Plik formatu pdf: Prosimy o wyrażenie zgody na wymianę drzwi frontowych",
                signed = false,
                description = "Pozwolenie na wymianę drzwi",
                creation_date = new DateTime(2024, 5, 15)
            };

            Document sampleEvent3 = new Document
            {
                DocumentId = 20,
                name = "Przykład ",
                content = "Plik formatu pdf: Przykładowe",
                signed = false,
                description = "Pozwolenie na Przykładowe",
                creation_date = new DateTime(2023, 12, 20)
            };

            modelBuilder.Entity<Document>().HasData(sampleEvent2);
            modelBuilder.Entity<Document>().HasData(sampleEvent);
            modelBuilder.Entity<Document>().HasData(sampleEvent3);
        }
    }
}
