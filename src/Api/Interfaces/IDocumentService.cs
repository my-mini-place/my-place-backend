using Domain;

namespace Api.Interfaces
{
    public interface IDocumentService
    {
        public IEnumerable<Document> GetDocuments();

        public Document GetDocumentById(int id);
    }
}