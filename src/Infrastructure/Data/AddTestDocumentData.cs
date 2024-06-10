using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
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
        public static byte[] ConvertStringToByteArray(string str)
        {
            Encoding encoding = Encoding.UTF8;

            byte[] byteArray = encoding.GetBytes(str);

            return byteArray;
        }

        public static void addTestDocumentData(this ModelBuilder modelBuilder)
        {

            Guid ManagerGuid = Guid.NewGuid();

            Document sampleEvent = CreateDocument(10, "Plik formatu pdf: Prosimy o wyrażenie zgody o zorganizowanie wydarzenia", "Organizacja pikniku",-3);

            Document sampleEvent2 = CreateDocument(15, "Plik formatu pdf: Prosimy o wyrażenie zgody na wymianę drzwi frontowych", "Wymiana drzwi",-4);

            Document sampleEvent3 = CreateDocument(20, "Plik formatu pdf: Przykładowe", "Przykład",-2);

            modelBuilder.Entity<Document>().HasData(sampleEvent2);
            modelBuilder.Entity<Document>().HasData(sampleEvent);
            modelBuilder.Entity<Document>().HasData(sampleEvent3);
        }
    }
}
