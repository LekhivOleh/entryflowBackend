using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController(IAdminService adminService, IValidatorService validatorService) : ControllerBase
{
    [HttpGet("{id}", Name = "GetAdminById")]
    public async Task<IActionResult> GetAdminById(Guid id)
    {
        try
        {
            var admin = await adminService.GetAdminByIdAsync(id);
            return Ok(admin);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet(Name = "GetAllAdmins")]
    public async Task<IActionResult> GetAllAdmins()
    {
        var admins = await adminService.GetAllAdminsAsync();
        return Ok(admins);
    }

    [HttpPost(Name = "AddAdmin")]
    public async Task<IActionResult> AddAdmin(AdminRequestDto adminDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdAdmin = await adminService.CreateAdminAsync(adminDto);
            return CreatedAtAction(nameof(GetAdminById), new { id = createdAdmin.Id }, createdAdmin);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}", Name = "UpdateAdmin")]
    public async Task<IActionResult> UpdateAdmin(Guid id, AdminUpdateDto adminDto)
    {
        try
        {
            await adminService.UpdateAdminAsync(id, adminDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}", Name = "DeleteAdmin")]
    public async Task<IActionResult> DeleteAdmin(Guid id)
    {
        try
        {
            await adminService.DeleteAdmin(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }       
    }
}
