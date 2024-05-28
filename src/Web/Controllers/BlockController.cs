using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Domain.Entities;
using Domain.Errors;
using Api.DTO.Blocks;

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
        public async Task<IActionResult> GetAllBlocks()
        {
            var result = await _service.GetAllBlocks();
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
        public async Task<IActionResult> CreateBlock([FromBody]  BlockCreateDTO blockCreateDTO)
        {
            var result = await _service.AddBlock(blockCreateDTO);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateBlock( [FromBody] BlockDTO block)
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