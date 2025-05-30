using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IRfidLogService
{
    Task<RfidLogDto> GetRfidLogByIdAsync(Guid id);
    Task<IEnumerable<RfidLogDto>> GetAllRfidLogsAsync();
    Task<RfidLogDto> AddRfidLogAsync(RfidLogRequestDto rfidLogDto);
    Task UpdateRfidLog(Guid id, RfidLogUpdateDto rfidLogDto);
    Task DeleteRfidLog(Guid id);
}