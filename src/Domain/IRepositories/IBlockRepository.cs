using Domain.Entities;
using Domain.Repositories;

namespace Domain.IRepositories
{
    public interface IBlockRepository : IPagedRepository<Block>
    {
    }
}