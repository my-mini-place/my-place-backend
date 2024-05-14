using Domain.IRepositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using static Domain.Models.Calendar.CalendarModels;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
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