using Api.DTO.Blocks;
using Api.DTO.Residence;
using Domain;

namespace Api.Services
{
    public interface IResidenceAndBlockService
    {
        Task<Result<PagedList<BlockDTO>>> GetAllBlocks(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder);

        Task<Result<BlockDTO>> GetBlockById(string id);

        Task<Result> AddBlock(BlockCreateDTO block);

        Task<Result> UpdateBlock(BlockDTO block);

        Task<Result> DeleteBlock(string id);

        Task<Result<PagedList<ResidenceDTO>>> GetAllResidences(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder);

        Task<Result<ResidenceDTO>> GetResidenceById(string id);

        Task<Result> AddResidence(ResidenceCreateDTO residence);

        Task<Result> UpdateResidence(ResidenceUpdate residence, string id);

        Task<Result> DeleteResidence(string id);
    }
}