using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;
using Microsoft.AspNetCore.Identity;

namespace entryflowBackend.API.Services;

public class AdminService(
    IAdminRepository adminRepository,
    IValidatorRepository validatorRepository,
    IPasswordHasher<Admin> passwordHasher) : IAdminService
{
    public async Task<AdminDto> GetAdminByIdAsync(Guid id)
    {
        var admin = await adminRepository.GetAdminByIdAsync(id);
        var validator = admin.Validator;

        if (validator == null)
        {
            throw new Exception("Validator not found");
        }

        return new AdminDto
        {
            Id = admin.Id,
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            Email = admin.Email,
            Validator = new ValidatorDto()
            {
                Id = validator.Id,
                Name = validator.Name
            },
            ValidatorId = admin.ValidatorId
        };
    }

    public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
    {
        var admins = await adminRepository.GetAllAdminsAsync();

        return admins.Select(a => new AdminDto
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            Email = a.Email,
            Validator = new ValidatorDto
            {
                Id = a.Validator.Id,
                Name = a.Validator.Name
            },
            ValidatorId = a.ValidatorId
        });
    }

    public async Task<AdminDto> CreateAdminAsync(AdminRequestDto adminDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(adminDto.ValidatorId);

        if (validator == null)
        {
            throw new Exception("Validator not found.");
        }

        var admin = new Admin
        {
            Id = Guid.NewGuid(),
            FirstName = adminDto.FirstName,
            LastName = adminDto.LastName,
            Email = adminDto.Email,
            ValidatorId = validator.Id,
            Password = adminDto.Password,
            Validator = validator
        };

        admin.Password = passwordHasher.HashPassword(admin, adminDto.Password);

        await adminRepository.AddAdminAsync(admin);
        await adminRepository.SaveChangesAsync();

        return new AdminDto
        {
            Id = admin.Id,
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            Email = admin.Email,
            Validator = new ValidatorDto
            {
                Id = validator.Id,
                Name = validator.Name
            },
            ValidatorId = admin.ValidatorId
        };
    }


    public async Task UpdateAdminAsync(Guid id, AdminUpdateDto adminDto)
    {
        var admin = await adminRepository.GetAdminByIdAsync(id);
        
        if (!string.IsNullOrEmpty(adminDto.FirstName))
            admin.FirstName = adminDto.FirstName;
        if (!string.IsNullOrEmpty(adminDto.LastName))
            admin.LastName = adminDto.LastName;

        adminRepository.UpdateAdmin(admin);
        await adminRepository.SaveChangesAsync();
    }

    public async Task DeleteAdmin(Guid id)
    {
        var admin = await adminRepository.GetAdminByIdAsync(id);
        adminRepository.DeleteAdmin(admin);
        await adminRepository.SaveChangesAsync();
    }
}
