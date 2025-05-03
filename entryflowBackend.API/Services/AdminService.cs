using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;

namespace entryflowBackend.API.Services;

public class AdminService : IAdminService
{
    public Task<AdminDto> GetAdminByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CreateAdminDto> CreateAdminAsync(CreateAdminDto dto)
    {
        throw new NotImplementedException();
    }

    public void UpdateAdminAsync(UpdateAdminDto dto)
    {
        throw new NotImplementedException();
    }

    public void DeleteAdmin(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}