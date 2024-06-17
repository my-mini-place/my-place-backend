using Api.DTO.Blocks;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace My_Place_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IResidenceAndBlockService _service;

        public BlockController(IResidenceAndBlockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlocks(int page, int pageSize, string? searchTerm, string ?sortColumn, string? sortOrder)
        {
            var result = await _service.GetAllBlocks(page,pageSize,searchTerm,sortColumn,sortOrder);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlock(string id)
        {
            var result = await _service.GetBlockById(id);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlock([FromBody] BlockCreateDTO blockCreateDTO)
        {
            var result = await _service.AddBlock(blockCreateDTO);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateBlock([FromBody] BlockDTO block)
        {
            var result = await _service.UpdateBlock(block);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlock(string id)
        {
            var result = await _service.DeleteBlock(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }
}