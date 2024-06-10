using Domain.IRepositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Document.DocumentModels;
using Domain;
using System.Linq.Expressions;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<Document> dbSet;
        public DocumentRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
            this.dbSet = _db.Set<Document>();

        }
        public void Update(Document obj)
        {
            try
            {
                dbSet.Update(obj);
                _db.SaveChanges();

            }
            catch
            {
            }
        }

    }
}
