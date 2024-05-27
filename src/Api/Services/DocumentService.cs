using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Errors;
using Domain.IRepositories;
using Api.Interfaces;
using AutoMapper;
using Domain;
using Domain.ExternalInterfaces;
using Domain.Repositories;
using static Domain.Models.Document.DocumentModels;
using static Domain.Calendar;


namespace Api.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;

        }

        public  async Task<Result<IEnumerable<Document>>> GetDocuments()
        {
            var documents = await _documentRepository.GetAll();

            var documentsEnumerable = documents.Cast<Document>();

            return Result.Success(documentsEnumerable);
        }


        public async Task<Result<Document>> GetDocumentById(int id)
        {

           var documents = await _documentRepository.GetAll(x => x.DocumentId == id);

            if (documents.Count != 0)
            {
                return Result.Success(documents[0]);
            }
            else
            {
                return Result.Failure<Document>(Error.Failure("Couldn't find such document!", "No such index of document exist!"));
            }
            
        }



    }
}
