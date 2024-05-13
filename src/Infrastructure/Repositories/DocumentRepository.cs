using Domain.IRepositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Document.DocumentModels;
using Domain;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : Repository<Event>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext db) : base(db)
        {

            
        }

        public List<Document> GetAll()
        {

            return null;
        }
    }
}
