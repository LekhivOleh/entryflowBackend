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
            Password = admin.Password,
            Validator = new ValidatorDto()
            {
                Id = validator.Id,
                Name = validator.Name,
                SecretKey = validator.SecretKey
            }
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
            Password = a.Password,
            Validator = new ValidatorDto()
            {
                Id = a.Validator.Id,
                Name = a.Validator.Name,
                SecretKey = a.Validator.SecretKey
            }
        });
    }

    public async Task<AdminDto> CreateAdminAsync(AdminRequestDto adminDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(adminDto.Validator.Id);

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
            Validator = new Validator
            {
                Id = validator.Id,
                Name = validator.Name,
                SecretKey = validator.SecretKey
            }
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
            Password = admin.Password,
            Validator = new ValidatorDto()
            {
                Id = validator.Id,
                Name = validator.Name,
                SecretKey = validator.SecretKey
            }
        };
    }


    public async Task UpdateAdminAsync(Guid id, AdminRequestDto adminDto)
    {
        var admin = await adminRepository.GetAdminByIdAsync(id);
        admin.FirstName = adminDto.FirstName ?? throw new ArgumentNullException(nameof(adminDto));
        admin.LastName = adminDto.LastName ?? throw new ArgumentNullException(nameof(adminDto));
        admin.Email = adminDto.Email ?? throw new ArgumentNullException(nameof(adminDto));

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