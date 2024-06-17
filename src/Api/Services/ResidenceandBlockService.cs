using Api.DTO.Blocks;
using Api.DTO.Residence;
using Api.IRepositories;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Errors;
using Domain.IRepositories;
using Domain.Models.Identity;

namespace Api.Services
{
    public class ResidenceAndBlockService : IResidenceAndBlockService
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IResidenceRepository _residenceRepository;
        private readonly IMapper _mapper;

        public ResidenceAndBlockService(IBlockRepository blockRepository, IResidenceRepository residenceRepository, IMapper mapper)
        {
            _blockRepository = blockRepository;
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<BlockDTO>>> GetAllBlocks(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder)
        {
            try
            {
                var blocks = await _blockRepository.GetAll(page,pageSize);

                var blocklist = blocks.Items.Select(element => _mapper.Map<BlockDTO>(element)).ToList();

                PagedList<BlockDTO> blocksDTOPaged = new PagedList<BlockDTO>(blocklist, blocks.TotalCount, blocks.PageIndex, blocks.PageSize);






                return Result.Success(blocksDTOPaged);
            }
            catch (System.Exception)
            {
                return Result.Failure<PagedList<BlockDTO>>(Error.Failure("GetAllBlocksFailure", "Unable to retrieve blocks"));
            }
        }

        public async Task<Result<BlockDTO>> GetBlockById(string id)
        {
            var block = await _blockRepository.Get(b => b.BlockId == id);
            if (block != null)
                return Result.Success(_mapper.Map<BlockDTO>(block));

            return Result.Failure<BlockDTO>(Error.NotFound("NotFound", $"Block with ID {id} not found"));
        }

        public async Task<Result> AddBlock(BlockCreateDTO block)
        {
            // validacja do dodania

            // automaper do dodania
            Block newBlock = new Block
            {
                Name = block.Name,
                BlockId = Guid.NewGuid().ToString(),
                PostalCode = block.PostalCode,
                Floors = block.floors,
                Number=block.number,
                Street = block.street,
                
            };

            try
            {
                await _blockRepository.Add(newBlock);
                await _blockRepository.Save();
                return Result.Success();
            }
            catch
            {
                return Result.Failure(Error.Failure("AddBlockFailure", "Error adding block"));
            }
        }

        public async Task<Result> UpdateBlock(BlockDTO block)
        {
            try
            {
                var updateblock = await _blockRepository.Get(b => b.BlockId == block.BlockId);

                if (updateblock == null)
                    return Result.Failure(Error.NotFound("NotFound", $"Block with ID {block.BlockId} not found"));

                updateblock.Name = block.Name ?? updateblock.Name;
                updateblock.PostalCode = block.PostalCode ?? updateblock.PostalCode;
                updateblock.Floors = block.Floors ?? updateblock.Floors;
                updateblock.Street= block.Street ?? updateblock.Street;
                updateblock.Number= block.Number ?? updateblock.Number;

                _blockRepository.Update(updateblock);

                await _blockRepository.Save();
                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("UpdateBlockFailure", "Error updating block"));
            }
        }

        public async Task<Result> DeleteBlock(string id)
        {
            try
            {
                var block = await _blockRepository.Get(b => b.BlockId == id);
                if (block == null)
                    return Result.Failure(Error.NotFound("NotFound", $"Block with ID {id} not found"));

                var residences = await _residenceRepository.Get(r => r.BlockId == id);

                if (residences==null)
                {
                    return Result.Failure(Error.Failure("DeleteBlockFailure", "Block has residences, cannot delete"));
                }

                _blockRepository.Remove(block);

                await _blockRepository.Save();

                return Result.Success();
            }
            catch (System.Exception)
            {
                return Result.Failure(Error.Failure("DeleteBlockFailure", "Error deleting block"));
            }
        }

        public async Task<Result<PagedList<ResidenceDTO>>> GetAllResidences(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder)
        {
            try
            {
                var residences = await _residenceRepository.GetAll(page, pageSize);

                var residenceList = residences.Items.Select(element => _mapper.Map<ResidenceDTO>(element)).ToList();


                var PagedResidenceDTO = new PagedList<ResidenceDTO>(residenceList, residences.TotalCount, residences.PageSize, residences.PageSize);


                return Result.Success(PagedResidenceDTO);
            }
            catch (Exception)
            {
                return Result.Failure<PagedList<ResidenceDTO>>(Error.Failure("GetAllResidencesFailure", "Unable to retrieve residences"));
            }
        }

        public async Task<Result<ResidenceDTO>> GetResidenceById(string id)
        {
            try
            {
                var residence = await _residenceRepository.Get(r => r.ResidenceId == id);
                if (residence != null)
                    return Result.Success(_mapper.Map<ResidenceDTO>(residence));

                return Result.Failure<ResidenceDTO>(Error.NotFound("NotFound", $"Residence with ID {id} not found"));
            }
            catch (System.Exception)
            {
                return Result.Failure<ResidenceDTO>(Error.Failure("GetResidenceFailure", "Error retrieving residence"));
            }
        }

        public async Task<Result> AddResidence(ResidenceCreateDTO residence)
        {
            try
            {
                var block = await _blockRepository.Get(b => b.BlockId == residence.BlokId);
                if (block == null)
                    return Result.Failure(Error.NotFound("NotFound", $"Block with ID {residence.BlokId} not found"));

                Residence newResidence = new Residence
                {
                    ResidenceId = Guid.NewGuid().ToString(),
                    Floor = residence.Floor,
                    ApartmentNumber = residence.ApartmentNumber,
                    BuildingNumber = residence.BuildingNumber,
                    Street = residence.Street,
                    BlockId = residence.BlokId,
                };

                await _residenceRepository.Add(newResidence);

                await _residenceRepository.Save();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(Error.Failure("AddResidenceFailure", "Error adding residence"));
            }
        }

        public async Task<Result> UpdateResidence(ResidenceUpdate residence, string ResidenceId)
        {
            try
            {
                var residenceToUpdate = await _residenceRepository.Get(r => r.ResidenceId == ResidenceId);
                if (residenceToUpdate == null)
                    return Result.Failure(Error.NotFound("NotFound", $"Residence with ID {ResidenceId} not found"));

                residenceToUpdate.Street = residence.Street ?? residenceToUpdate.Street;
                residenceToUpdate.BuildingNumber = residence.BuildingNumber ?? residenceToUpdate.BuildingNumber;
                residenceToUpdate.ApartmentNumber = residence.ApartmentNumber ?? residenceToUpdate.ApartmentNumber;
                residenceToUpdate.Floor = residence.Floor ?? residenceToUpdate.Floor;

                _residenceRepository.Update(residenceToUpdate);
                await _residenceRepository.Save();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(Error.Failure("UpdateResidenceFailure", "Error updating residence"));
            }
        }

        public async Task<Result> DeleteResidence(string id)
        {
            try
            {
                var ResidenceToDelete = await _residenceRepository.Get(r => r.ResidenceId == id);

                if (ResidenceToDelete == null)
                    return Result.Failure(Error.NotFound("NotFound", $"Residence with ID {id} not found"));

                _residenceRepository.Remove(ResidenceToDelete);

                await _residenceRepository.Save();

                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(Error.Failure("DeleteResidenceFailure", "Error deleting residence"));
            }
        }
    }
}