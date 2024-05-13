using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using My_Place_Backend.DTO.Auth;
using System.Threading.Tasks;
using static Domain.Document;
using static Domain.Calendar;
using Domain.IRepositories;

namespace Api.Interfaces
{
    public interface IDocumentService
    {
        
        public IEnumerable<Document> GetDocuments();

        public Document GetDocumentById(int id);
    }
}
