using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors]
public class AdminController(IAdminService adminService, IValidatorService validatorService, JwtTokenProvider jwtTokenProvider, IPasswordHasher<entryflowBackend.API.Models.Admin> passwordHasher) : ControllerBase
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

    [HttpPost("register", Name = "RegisterAdmin")]
    public async Task<IActionResult> Register(AdminRegisterWithSecretDto adminDto)
    {
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validator = await validatorService.GetValidatorBySecretAsync(adminDto.ValidatorSecret);
            if (validator == null)
                return BadRequest("Invalid validator secret.");

            var adminRequest = new AdminRequestDto
            {
                FirstName = adminDto.FirstName,
                LastName = adminDto.LastName,
                Email = adminDto.Email,
                Password = adminDto.Password,
                ValidatorId = validator.Id
            };

            var createdAdmin = await adminService.CreateAdminAsync(adminRequest);
            var token = jwtTokenProvider.Create(new entryflowBackend.API.Models.Admin
            {
                Id = createdAdmin.Id,
                Email = createdAdmin.Email,
                FirstName = createdAdmin.FirstName,
                LastName = createdAdmin.LastName,
                ValidatorId = createdAdmin.ValidatorId,
                Password = ""
            });

            return Ok(new { admin = createdAdmin, token });
        }
    }

    [HttpPost("login", Name = "LoginAdmin")]
    public async Task<IActionResult> Login(AdminLoginDto loginDto)
    {
        {
            var admin = await adminService.GetAdminByEmailAsync(loginDto.Email);
            if (admin == null)
                return Unauthorized("Invalid credentials");

            var adminModel = new entryflowBackend.API.Models.Admin
            {
                Id = admin.Id,
                Email = admin.Email,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                ValidatorId = admin.ValidatorId,
                Password = ""
            };

            var passwordVerification = await adminService.VerifyPasswordAsync(loginDto.Email, loginDto.Password);
            if (!passwordVerification)
                return Unauthorized("Invalid credentials");

            var token = jwtTokenProvider.Create(adminModel);

            return Ok(new { admin, token });
        }
    }

    [HttpGet("by-email/{email}", Name = "GetAdminByEmail")]
    public async Task<IActionResult> GetAdminByEmail(string email)
    {
        try
        {
            var admin = await adminService.GetAdminByEmailAsync(email);
            if (admin == null)
                return NotFound("Admin not found");
            return Ok(admin);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}