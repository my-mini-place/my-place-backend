using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Domain.Entities;
using Domain.Errors;
using Domain;

namespace My_Place_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidenceController : ControllerBase
    {
        private readonly IResidenceAndBlockService _service;

        public ResidenceController(IResidenceAndBlockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResidences()
        {
            var result = await _service.GetAllResidences();
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidence(int id)
        {
            var result = await _service.GetResidenceById(id);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResidence([FromBody] Residence residence)
        {
            var result = await _service.AddResidence(residence);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return CreatedAtAction(nameof(GetResidence), new { id = residence.Id }, residence);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResidence(int id)
        {
            Result<Residence> residence = await _service.GetResidenceById(id);

            if (id != residence.Value.Id)
            {
                return BadRequest();
            }

            var result = _service.UpdateResidence(residence.Value);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidence(int id)
        {
            var result = _service.DeleteResidence(id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }
    }
}