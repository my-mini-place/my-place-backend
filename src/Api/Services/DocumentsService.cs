using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Document;
using Domain.Errors;
using Domain.IRepositories;
using Api.Interfaces;
using AutoMapper;
using Domain;
using Domain.ExternalInterfaces;
using Domain.Repositories;

namespace Api.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public IEnumerable<Document> GetDocuments()
        {
            List<Document> documents = new List<Document>();
            documents = _documentRepository.GetAll();
            return documents;
        }

        public Document GetDocumentById(int id)
        {
            List<Document> documents = new List<Document>();
            documents = _documentRepository.GetAll();

            foreach (var document in documents)
            {
                if (document.Id == id)
                    return document;
            }

            return null;
        }
    }
}