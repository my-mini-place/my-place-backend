using Domain;
using Domain.Entities;
using Domain.Errors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IResidenceAndBlockService
    {
        Task<Result<List<Block>>> GetAllBlocks();

        Task<Result<Block>> GetBlockById(int id);

        Task<Result> AddBlock(Block block);

        Task<Result> UpdateBlock(Block block);

        Task<Result> DeleteBlock(int id);

        Task<Result<List<Residence>>> GetAllResidences();

        Task<Result<Residence>> GetResidenceById(int id);

        Task<Result> AddResidence(Residence residence);

        Result UpdateResidence(Residence residence);

        Result DeleteResidence(int id);
    }
}