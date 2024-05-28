using Domain;
using Domain.IRepositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext db) : base(db)
        {
        }

        public List<Document> GetAll()
        {
            return null!;
        }
    }
}