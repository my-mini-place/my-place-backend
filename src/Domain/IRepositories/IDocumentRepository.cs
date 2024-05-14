using Domain.Repositories;

namespace Domain.IRepositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        public List<Document> GetAll();
    }
}