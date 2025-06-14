using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors]
public class RfidLogController(IRfidLogService rfidLogService) : ControllerBase
{
    [HttpGet(Name = "GetAllRfidLogs")]
    public async Task<IActionResult> GetAllRfidLogs()
    {
        var rfidLogs = await rfidLogService.GetAllRfidLogsAsync();
        return Ok(rfidLogs);
    }
    
    [HttpGet("by-admin/{email}", Name = "GetAllRfidLogsByAdmin")]
    public async Task<IActionResult> GetAllRfidLogsByAdmin(string email)
    {
        try
        {
            var rfidLogs = await rfidLogService.GetAllRfidLogsByAdminAsync(email);
            return Ok(rfidLogs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("by-date", Name = "GetAllRfidLogsByDate")]
    public async Task<IActionResult> GetAllRfidLogsByDate(DateTime date)
    {
        try
        {
            var rfidLogs = await rfidLogService.GetAllRfidLogsByDateAsync(date);
            return Ok(rfidLogs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
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
            return CreatedAtAction(nameof(AddRfidLog), new { id = rfidLog.Id }, rfidLog);       
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