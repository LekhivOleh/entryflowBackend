using entryflowBackend.API.Models;

namespace entryflowBackend.API.Interfaces.Repositories;

public interface IAdminRepository
{
    Task<Admin> GetAdminByIdAsync(Guid id);
    Task<IEnumerable<Admin>> GetAllAdminsAsync();
    Task AddAdminAsync(Admin admin);
    void UpdateAdmin(Admin admin);
    void DeleteAdmin(Admin admin);
    Task SaveChangesAsync();
    Task<Admin?> GetAdminByEmailAsync(string email);
}