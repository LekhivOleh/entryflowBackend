using entryflowBackend.API.DTOs;
using entryflowBackend.API.Models;

namespace entryflowBackend.API.Interfaces.Services;

public interface IRfidLogService
{
    Task<IEnumerable<RfidLogDto>> GetAllRfidLogsAsync();
    Task<IEnumerable<RfidLogDto>> GetAllRfidLogsByAdminAsync(string email);
    Task<IEnumerable<RfidLogDto>> GetAllRfidLogsByDateAsync(DateTime date);
    Task<RfidLogDto> AddRfidLogAsync(RfidLogRequestDto rfidLogDto);
    Task UpdateRfidLog(Guid id, RfidLogUpdateDto rfidLogDto);
    Task DeleteRfidLog(Guid id);
}