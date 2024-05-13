using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Document.DocumentModels;

namespace Domain.IRepositories
{
    public interface IDocumentRepository : IRepository<Event>
    {
        public List<Document> GetAll();


    }
}
