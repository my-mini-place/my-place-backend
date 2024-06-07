using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Document.DocumentModels;

namespace Domain.IRepositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
       // public List<Document> GetAll();
    }
}