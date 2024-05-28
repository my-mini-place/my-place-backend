using Api.DTO.Residence;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

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
                return BadRequest(result.ToProblemDetails());
            }
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidence(string id)
        {
            var result = await _service.GetResidenceById(id);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResidence([FromBody] ResidenceCreateDTO residence)
        {
            var result = await _service.AddResidence(residence);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResidence(ResidenceUpdate residenceUpdate, string id)
        {
            var result = await _service.UpdateResidence(residenceUpdate, id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidence(string id)
        {
            var result = await _service.DeleteResidence(id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }
    }
}