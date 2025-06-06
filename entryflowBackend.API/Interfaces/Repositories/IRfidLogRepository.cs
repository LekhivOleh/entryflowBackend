using entryflowBackend.API.DTOs;
using entryflowBackend.API.Models;

namespace entryflowBackend.API.Interfaces.Repositories;

public interface IRfidLogRepository
{
    Task<RfidLog> GetRfidLogByIdAsync(Guid id);
    Task<IEnumerable<RfidLog>> GetAllRfidLogsAsync();
    Task<IEnumerable<RfidLog>> GetAllRfidLogsByDateAsync(DateTime date);
    Task AddRfidLogAsync(RfidLog rfidLog);
    void UpdateRfidLog(RfidLog rfidLog);
    void DeleteRfidLog(RfidLog rfidLog);
    Task SaveChangesAsync();
}