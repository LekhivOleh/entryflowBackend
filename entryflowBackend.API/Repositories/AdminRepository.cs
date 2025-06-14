using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class AdminRepository(EntryflowDbContext context) : IAdminRepository
{
    public async Task<Admin> GetAdminByIdAsync(Guid id)
    {
        var admin = await context.Admins
            .Include(x => x.Validator)
            .SingleOrDefaultAsync(x => x.Id == id);
        return admin ?? throw new KeyNotFoundException($"Admin not found");
    }

    public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
    {
        var admins = await context
            .Admins
            .Include(x => x.Validator)
            .ToListAsync();
        return admins;
    }

    public async Task AddAdminAsync(Admin admin)
    {
        await context
            .Admins
            .AddAsync(admin ?? throw new ArgumentNullException(nameof(admin)));
    }

    public void UpdateAdmin(Admin admin)
    {
        context.Admins.Update(admin);
    }

    public void DeleteAdmin(Admin admin)
    {
        context.Admins.Remove(admin);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<Admin?> GetAdminByEmailAsync(string email)
    {
        return await context.Admins
            .Include(x => x.Validator)
            .SingleOrDefaultAsync(x => x.Email == email);
    }
}