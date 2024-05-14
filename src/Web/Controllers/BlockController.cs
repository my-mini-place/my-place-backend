using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Domain.Entities;
using Domain.Errors;

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
        public async Task<IActionResult> GetBlock(int id)
        {
            var result = await _service.GetBlockById(id);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlock([FromBody] Block block)
        {
            var result = await _service.AddBlock(block);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return CreatedAtAction(nameof(GetBlock), new { id = block.Id }, block);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlock(int id, [FromBody] Block block)
        {
            if (id != block.Id)
            {
                return BadRequest();
            }

            var result = await _service.UpdateBlock(block);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlock(int id)
        {
            var result = await _service.DeleteBlock(id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }
    }
}