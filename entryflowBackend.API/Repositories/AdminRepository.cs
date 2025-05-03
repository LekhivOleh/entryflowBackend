using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class AdminRepository(EntryflowDbContext context) : IAdminRepository
{
    public async Task<Admin> GetAdminByIdAsync(Guid id)
    {
        var admin = await context.Admins.SingleOrDefaultAsync(x => x.Id == id);
        return admin ?? throw new KeyNotFoundException($"Admin not found");
    }

    public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
    {
        return await context.Admins.ToListAsync();
    }

    public async Task AddAdminAsync(Admin admin)
    {
        await context.Admins.AddAsync(admin ?? throw new ArgumentNullException(nameof(admin)));
    }

    public void UpdateAdmin(Admin admin)
    {
        context.Admins.Update(admin ?? throw new ArgumentNullException(nameof(admin)));
    }

    public void DeleteAdmin(Admin admin)
    {
        context.Admins.Remove(admin ?? throw new ArgumentNullException(nameof(admin)));
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}