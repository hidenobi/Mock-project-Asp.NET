using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgrammeController : ControllerBase
{
    private readonly IProgrammeService _programmeService;

    public ProgrammeController(IProgrammeService programmeService)
    {
        _programmeService = programmeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Programme>>> GetProgrammes()
    {
        var programmes = await _programmeService.GetAllProgrammesAsync();
        return Ok(programmes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Programme>> GetProgramme(int id)
    {
        var programme = await _programmeService.GetProgrammeByIdAsync(id);
        if (programme == null)
        {
            return NotFound();
        }

        return Ok(programme);
    }

    [HttpPost]
    public async Task<ActionResult<Programme>> CreateProgramme(Programme programme)
    {
        await _programmeService.AddProgrammeAsync(programme);
        return CreatedAtAction(nameof(GetProgramme), new { id = programme.Id }, programme);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProgramme(int id, Programme programme)
    {
        if (id != programme.Id)
        {
            return BadRequest();
        }

        var existingProgramme = await _programmeService.GetProgrammeByIdAsync(id);
        if (existingProgramme == null)
        {
            return NotFound();
        }

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