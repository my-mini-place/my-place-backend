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
using Microsoft.EntityFrameworkCore;
using Domain.Models.Identity;



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

        public async Task<Result<IEnumerable<Document>>> GetDocumentsByUserId(int userId)
        {
            var documents = await _documentRepository.GetAll();

            documents = documents.Where(doc => doc.UserId == userId).ToList();

            var documentsEnumerable = documents.Cast<Document>();

            return Result.Success(documentsEnumerable);
        }

        public async Task<Result<Document>> GetDocumentById(int id)
        {

            if (id < 0)
            {
                return Result.Failure<Document>(Error.Failure("Wrong index", "No such index of document exist!"));
            }

           List<Document> documents = await _documentRepository.GetAll(x => x.DocumentId == id, null);



            if (documents != null)
            {
                if (documents.Count == 0)
                {
                    return Result.Failure<Document>(Error.Failure("There are no Documents!", "No such index of document exist!"));
                }
                return Result.Success(documents[0]);
            }
            else
            {
                
                return Result.Failure<Document>(Error.Failure("Couldn't find such document!", "No such index of document exist!"));
            }
            
        }


        public async Task<Result<string>> AddDocument(DocumentDto documentDto)
        {
            string id = Guid.NewGuid().ToString();
            int Id;
            int.TryParse(id, out Id);
            documentDto.DocumentId = Id;
            await _documentRepository.Add(DocumentMapper.castDtoDocumentToDocument(documentDto));

            await _documentRepository.Save();
            return Result.Success(id);
        }

        public void Update(Document document)
        {
            _documentRepository.Update(document);
        }



    }
}
