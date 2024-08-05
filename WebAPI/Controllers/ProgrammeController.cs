using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammeController : ControllerBase
    {
        private readonly IProgrammeService _programmeService;
        private readonly ContactService _contactService;

        public ProgrammeController(IProgrammeService programmeService, ContactService contactService)
        {
            _programmeService = programmeService;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammeDto>>> GetProgrammes()
        {
            var programmes = await _programmeService.GetAllProgrammesAsync();
            var programmeDtos = programmes.Select(p => new ProgrammeDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ContactId = p.ContactId,
                IsActive = p.IsActive
            }).ToList();

            return Ok(programmeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammeDto>> GetProgramme(int id)
        {
            var programme = await _programmeService.GetProgrammeByIdAsync(id);
            if (programme == null)
            {
                return NotFound();
            }

            var programmeDto = new ProgrammeDto
            {
                Id = programme.Id,
                Name = programme.Name,
                Description = programme.Description,
                ContactId = programme.ContactId,
                IsActive = programme.IsActive
            };

            return Ok(programmeDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProgrammeDto>> CreateProgramme([FromBody] ProgrammeDto programmeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contact = await _contactService.GetContactById(programmeDto.ContactId);
                if (contact == null)
                {
                    return BadRequest("Invalid ContactID");
                }

                var programme = new Programme
                {
                    Name = programmeDto.Name,
                    Description = programmeDto.Description,
                    ContactId = programmeDto.ContactId,
                    IsActive = programmeDto.IsActive
                };

                await _programmeService.AddProgrammeAsync(programme);

                programmeDto.Id = programme.Id;

                return CreatedAtAction(nameof(GetProgramme), new { id = programme.Id }, programmeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgramme(int id, [FromBody] ProgrammeDto programmeDto)
        {
            if (id != programmeDto.Id)
            {
                return BadRequest();
            }

            var existingProgramme = await _programmeService.GetProgrammeByIdAsync(id);
            if (existingProgramme == null)
            {
                return NotFound();
            }

            var programme = new Programme
            {
                Id = programmeDto.Id,
                Name = programmeDto.Name,
                Description = programmeDto.Description,
                ContactId = programmeDto.ContactId,
                IsActive = programmeDto.IsActive
            };

            await _programmeService.UpdateProgrammeAsync(programme);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramme(int id)
        {
            var programme = await _programmeService.GetProgrammeByIdAsync(id);
            if (programme == null)
            {
                return NotFound();
            }

            await _programmeService.DeleteProgrammeAsync(id);

            return NoContent();
        }
    }
}
