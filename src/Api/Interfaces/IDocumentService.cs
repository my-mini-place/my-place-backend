using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using My_Place_Backend.DTO.Auth;
using System.Threading.Tasks;
using static Domain.Models.Document.DocumentModels;
using static Domain.Calendar;
using Domain.IRepositories;

namespace Api.Interfaces
{
    public interface IDocumentService
    {
        
        public Task<Result<IEnumerable<Document>>> GetDocuments();

        Task<Result<Document>> GetDocumentById(int id);

        Task<Result<string>> AddDocument(DocumentDto documentDto);
    }
}
