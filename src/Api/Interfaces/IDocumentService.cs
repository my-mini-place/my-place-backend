
﻿using System;
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
using static Domain.Models.Documents.Documents;
﻿using Domain;

namespace Api.Interfaces
{
    public interface IDocumentService
    {
        
        Task<Result<IEnumerable<Document>>> GetDocuments();
        Task<Result<IEnumerable<Document>>> GetDocumentsByUserId(int userId);
        Task<Result<Document>> GetDocumentById(int id);
        Task<Result<string>> AddDocument(DocumentDto documentDto);

        void Update(Document document);

    }
}
