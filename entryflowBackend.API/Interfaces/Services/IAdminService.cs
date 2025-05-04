using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IAdminService
{
    Task<AdminDto> GetAdminByIdAsync(Guid id);
    Task<IEnumerable<AdminDto>> GetAllAdminsAsync();
    Task<AdminDto> CreateAdminAsync(CreateAdminDto dto);
    Task UpdateAdminAsync(Guid id, UpdateAdminDto dto);
    Task DeleteAdmin(Guid id);
}