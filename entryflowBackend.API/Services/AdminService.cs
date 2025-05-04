using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;
using entryflowBackend.API.Repositories;

namespace entryflowBackend.API.Services;

public class AdminService(IAdminRepository adminRepository, IValidatorRepository validatorRepository) : IAdminService
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
            Name = admin.Name,
            Email = admin.Email,
            Validator = new ValidatorBriefDto
            {
                Id = validator.Id,
                Name = validator.Name
            }
        };
    }

    public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
    {
        var admins = await adminRepository.GetAllAdminsAsync();

        return admins.Select(a => new AdminDto
        {
            Id = a.Id,
            Name = a.Name,
            Email = a.Email,
            Validator = new ValidatorBriefDto
            {
                Id = a.Validator.Id,
                Name = a.Validator.Name
            }
        });
    }

    public async Task<AdminDto> CreateAdminAsync(CreateAdminDto adminDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(adminDto.ValidatorId);

        if (validator == null)
        {
            throw new Exception("Validator not found.");
        }

        var admin = new Admin
        {
            Name = adminDto.Name,
            Email = adminDto.Email,
            PasswordHash = adminDto.PasswordHash,
            ValidatorId = validator.Id
        };

        await adminRepository.AddAdminAsync(admin);
        await adminRepository.SaveChangesAsync();

        return new AdminDto
        {
            Id = admin.Id,
            Name = admin.Name,
            Email = admin.Email,
            Validator = new ValidatorBriefDto
            {
                Id = validator.Id,
                Name = validator.Name
            }
        };
    }


    public async Task UpdateAdminAsync(Guid id, UpdateAdminDto adminDto)
    {
        var admin = await adminRepository.GetAdminByIdAsync(id);
        admin.Name = adminDto.Name ?? throw new ArgumentNullException(nameof(admin));
        admin.Email = adminDto.Email ?? throw new ArgumentNullException(nameof(admin));
        
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