using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValidatorController(IValidatorService validatorService) : ControllerBase
{
    [HttpGet("{id}", Name = "GetValidatorById")]
    public async Task<IActionResult> GetValidatorById(Guid id)
    {
        try
        {
            var validator = await validatorService.GetValidatorByIdAsync(id);
            return Ok(validator);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet(Name = "GetAllValidators")]
    public async Task<IActionResult> GetAllValidators()
    {
        var validators = await validatorService.GetAllValidatorsAsync();
        return Ok(validators);
    }

    [HttpPost(Name = "AddValidator")]
    public async Task<IActionResult> AddValidator(ValidatorRequestDto validatorRequestDto)
    {
        try
        {
            var validator = await validatorService.AddValidatorAsync(validatorRequestDto);
            return CreatedAtAction(nameof(AddValidator), new { id = validator.Id }, validator);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}", Name = "UpdateValidator")]
    public async Task<IActionResult> UpdateValidator(Guid id, ValidatorRequestDto validatorDto)
    {
        await validatorService.UpdateValidatorAsync(id, validatorDto);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteValidator")]
    public async Task<IActionResult> DeleteValidator(Guid id)
    {
        await validatorService.DeleteValidatorAsync(id);
        return NoContent();
    }
}