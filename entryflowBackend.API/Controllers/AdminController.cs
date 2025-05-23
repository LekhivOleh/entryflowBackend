using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController(IAdminService adminService, IValidatorService validatorService) : ControllerBase
{
    /// <summary>
    /// Retrieves an admin by their unique id.
    /// </summary>
    /// <param name="id">The unique identifier of the admin to retrieve.</param>
    /// <returns>
    /// Returns HTTP 200 OK response with the admin details if found, 
    /// or an HTTP 400 Bad Request response if an error occurs.
    /// </returns>
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
            return BadRequest(ex);
        }
    }

    /// <summary>
    /// Retrieves all admins.
    /// </summary>
    /// <returns>
    /// Returns HTTP 200 OK response with a list of admins.
    /// </returns>
    [HttpGet(Name = "GetAllAdmins")]
    public async Task<IActionResult> GetAllAdmins()
    {
        var admins = await adminService.GetAllAdminsAsync();
        return Ok(admins);
    }

    /// <summary>
    /// Creates a new admin and hashes the password.
    /// </summary>
    /// <param name="adminDto">Admin entity that consists of FirstName, LastName, Email, Password(not yet hashed) and Validator entity.</param>
    /// <returns>
    /// Returns HTTP 200 OK response with created admin if succeeds,
    /// or HTTP 400 Bad Request response if an error occurs.
    /// </returns>
    [HttpPost(Name = "AddAdmin")]
    public async Task<IActionResult> AddAdmin(AdminRequestDto adminDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(adminDto.Email)
                || string.IsNullOrWhiteSpace(adminDto.Password)
                || string.IsNullOrWhiteSpace(adminDto.FirstName)
                || string.IsNullOrWhiteSpace(adminDto.LastName)
                )
            {
                return BadRequest("Invalid admin data");
            }
            
            var validator = await validatorService.GetValidatorByIdAsync(adminDto.Validator.Id);
               
            var admin = new AdminRequestDto
            {
                FirstName = adminDto.FirstName,
                LastName = adminDto.LastName,
                Email = adminDto.Email,
                Password = adminDto.Password,
                Validator = new ValidatorDto
                {
                    Id = validator.Id,
                    SecretKey = validator.SecretKey,
                    Name = validator.Name
                }
            };

            var createdAdmin = await adminService.CreateAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdminById), createdAdmin.Id , createdAdmin);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Updates admin by unique identifier.
    /// </summary>
    /// <param name="id">A unique identifier of an admin to be updated.</param>
    /// <param name="adminDto">Admin entity that consists of FirstName, LastName, Email, Password(not yet hashed) and Validator entity.</param>
    /// <returns>
    /// Returns HTTP 204 No Content.
    /// </returns>
    [HttpPut("{id}", Name = "UpdateAdmin")]
    public async Task<IActionResult> UpdateAdmin(Guid id, AdminRequestDto adminDto)
    {
        await adminService.UpdateAdminAsync(id, adminDto);
        return NoContent();
    }

    /// <summary>
    /// Deletes admin by unique identifier.
    /// </summary>
    /// <param name="id">A unique identifier.</param>
    /// <returns>
    /// Returns HTTP 204 No Content.
    /// </returns>
    [HttpDelete("{id}", Name = "DeleteAdmin")]
    public async Task<IActionResult> DeleteAdmin(Guid id)
    {
        await adminService.DeleteAdmin(id);
        return NoContent();
    }
}