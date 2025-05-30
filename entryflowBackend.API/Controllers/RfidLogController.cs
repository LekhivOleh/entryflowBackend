using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RfidLogController(IRfidLogService rfidLogService) : ControllerBase
{
    [HttpGet("{id}", Name = "GetRfidLogById")]
    public async Task<IActionResult> GetRfidLogById(Guid id)
    {
        try
        {
            var rfidLog = await rfidLogService.GetRfidLogByIdAsync(id);
            return Ok(rfidLog);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet(Name = "GetAllRfidLogs")]
    public async Task<IActionResult> GetAllRfidLogs()
    {
        var rfidLogs = await rfidLogService.GetAllRfidLogsAsync();
        return Ok(rfidLogs);
    }

    [HttpPost(Name = "AddRfidLog")]
    public async Task<IActionResult> AddRfidLog(RfidLogRequestDto rfidLogDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rfidLog = await rfidLogService.AddRfidLogAsync(rfidLogDto);
            return CreatedAtAction(nameof(GetRfidLogById), new { id = rfidLog.Id }, rfidLog);       
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);       
        }
    }
    
    [HttpPut(Name = "UpdateRfidLog")]
    public async Task<IActionResult> UpdateRfidLog(Guid id, RfidLogUpdateDto rfidLogDto)
    {
        await rfidLogService.UpdateRfidLog(id, rfidLogDto);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteRfidLog")]
    public async Task<IActionResult> DeleteRfidLog(Guid id)
    {
        await rfidLogService.DeleteRfidLog(id);
        return NoContent();       
    }
}
