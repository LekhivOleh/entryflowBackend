using entryflowBackend.API.DbContext;
using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class RfidLogRepository(EntryflowDbContext context) : IRfidLogRepository
{
    public async Task<RfidLog> GetRfidLogByIdAsync(Guid id)
    {
        var rfidLog = await context
            .RfidLogs
            .Include(r => r.Validator)
            .Include(r => r.Employee)
            .SingleOrDefaultAsync(x => x.Id == id);
        return rfidLog ?? throw new KeyNotFoundException("RfidLog not found");
    }

    public async Task<IEnumerable<RfidLog>> GetAllRfidLogsAsync()
    {
        var rfidLogs = await context
            .RfidLogs
            .Include(r => r.Validator)
            .Include(r => r.Employee)
            .ToListAsync();
        return rfidLogs;
    }

    public async Task<IEnumerable<RfidLog>> GetAllRfidLogsByAdminAsync(AdminDto admin)
    {
        var rfidLogs = await context
            .RfidLogs
            .Include(r => r.Validator)
            .Include(r => r.Employee)
            .Where(r => r.ValidatorId == admin.ValidatorId)
            .ToListAsync();
        return rfidLogs;
    }

    public async Task<IEnumerable<RfidLog>> GetAllRfidLogsByDateAsync(DateTime date)
    {
        var rfidLogs = await context
            .RfidLogs
            .Include(r => r.Validator)
            .Include(r => r.Employee)
            .Where(r => r.Timestamp == date)
            .ToListAsync();
        return rfidLogs;
    }

    public async Task AddRfidLogAsync(RfidLog rfidLog)
    {
        await context
            .RfidLogs
            .AddAsync(rfidLog ?? throw new ArgumentNullException(nameof(rfidLog)));
    }

    public void UpdateRfidLog(RfidLog rfidLog)
    {
        context
            .RfidLogs
            .Update(rfidLog ?? throw new ArgumentNullException(nameof(rfidLog)));
    }

    public void DeleteRfidLog(RfidLog rfidLog)
    {
        context
            .RfidLogs
            .Remove(rfidLog ?? throw new ArgumentNullException(nameof(rfidLog)));
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
