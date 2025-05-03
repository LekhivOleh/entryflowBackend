using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IAdminService
{
    Task<AdminDto> GetAdminByIdAsync(int id);
    Task<IEnumerable<AdminDto>> GetAllAdminsAsync();
    Task<CreateAdminDto> CreateAdminAsync(CreateAdminDto dto);
    void UpdateAdminAsync(UpdateAdminDto dto);
    void DeleteAdmin(int id);
    Task SaveChangesAsync();
}