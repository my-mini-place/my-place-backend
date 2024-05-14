using Api.Repositories;
using Domain;
using Domain.Entities;
using Domain.Errors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ResidenceAndBlockService : IResidenceAndBlockService
    {
        private readonly IRepository<Block> _blockRepository;
        private readonly IRepository<Residence> _residenceRepository;

        public ResidenceAndBlockService(IRepository<Block> blockRepository, IRepository<Residence> residenceRepository)
        {
            _blockRepository = blockRepository;
            _residenceRepository = residenceRepository;
        }

        public async Task<Result<List<Block>>> GetAllBlocks()
        {
            try
            {
                var blocks = await _blockRepository.GetAll();
                return Result.Success(blocks);
            }
            catch (System.Exception)
            {
                return Result.Failure<List<Block>>(Error.Failure("GetAllBlocksFailure", "Unable to retrieve blocks"));
            }
        }

        public async Task<Result<Block>> GetBlockById(int id)
        {
            try
            {
                var block = await _blockRepository.Get(b => b.Id == id);
                if (block != null)
                    return Result.Success(block);
                return Result.Failure<Block>(Error.NotFound("NotFound", $"Block with ID {id} not found"));
            }
            catch (System.Exception)
            {
                return Result.Failure<Block>(Error.Failure("GetBlockFailure", "Error retrieving block"));
            }
        }

        public async Task<Result> AddBlock(Block block)
        {
            try
            {
                await _blockRepository.Add(block);
                return Result.Success();
            }
            catch
            {
                return Result.Failure(Error.Failure("AddBlockFailure", "Error adding block"));
            }
        }

        public async Task<Result> UpdateBlock(Block block)
        {
            try
            {
                _blockRepository.Update(block);
                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("UpdateBlockFailure", "Error updating block"));
            }
        }

        public async Task<Result> DeleteBlock(int id)
        {
            try
            {
                _blockRepository.Remove(new Block { Id = id });
                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("DeleteBlockFailure", "Error deleting block"));
            }
        }

        public async Task<Result<List<Residence>>> GetAllResidences()
        {
            try
            {
                var residences = await _residenceRepository.GetAll();
                return Result.Success(residences);
            }
            catch (System.Exception)
            {
                return Result.Failure<List<Residence>>(Error.Failure("GetAllResidencesFailure", "Unable to retrieve residences"));
            }
        }

        public async Task<Result<Residence>> GetResidenceById(int id)
        {
            try
            {
                var residence = await _residenceRepository.Get(r => r.Id == id);
                if (residence != null)
                    return Result.Success(residence);
                return Result.Failure<Residence>(Error.NotFound("NotFound", $"Residence with ID {id} not found"));
            }
            catch (System.Exception)
            {
                return Result.Failure<Residence>(Error.Failure("GetResidenceFailure", "Error retrieving residence"));
            }
        }

        public async Task<Result> AddResidence(Residence residence)
        {
            try
            {
                await _residenceRepository.Add(residence);
                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("AddResidenceFailure", "Error adding residence"));
            }
        }

        public Result UpdateResidence(Residence residence)
        {
            try
            {
                _residenceRepository.Update(residence);
                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("UpdateResidenceFailure", "Error updating residence"));
            }
        }

        public Result DeleteResidence(int id)
        {
            try
            {
                _residenceRepository.Remove(new Residence { Id = id });
                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("DeleteResidenceFailure", "Error deleting residence"));
            }
        }
    }
}