using Api.Interfaces;
using Domain;
using Domain.IRepositories;

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