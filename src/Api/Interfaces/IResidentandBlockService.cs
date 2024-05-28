using Api.DTO.Blocks;
using Api.DTO.Residence;
using Domain;
using Domain.Entities;
using Domain.Errors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IResidenceAndBlockService
    {
        Task<Result<List<BlockDTO>>> GetAllBlocks();

        Task<Result<BlockDTO>> GetBlockById(string id);

        Task<Result> AddBlock(BlockCreateDTO block);

        Task<Result> UpdateBlock(BlockDTO block);

        Task<Result> DeleteBlock(string id);

        Task<Result<List<ResidenceDTO>>> GetAllResidences();

        Task<Result<ResidenceDTO>> GetResidenceById(string id);

        Task<Result> AddResidence(ResidenceCreateDTO residence);

        Task<Result> UpdateResidence(ResidenceUpdate residence,string id);

       Task< Result> DeleteResidence(string id);
    }
}