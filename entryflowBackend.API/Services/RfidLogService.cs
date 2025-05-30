using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;

namespace entryflowBackend.API.Services;

public class RfidLogService(
    IRfidLogRepository rfidLogRepository,
    IValidatorService validatorService,
    IEmployeeService employeeService
) : IRfidLogService
{
    public async Task<RfidLogDto> GetRfidLogByIdAsync(Guid id)
    {
        var rfidLog = await rfidLogRepository.GetRfidLogByIdAsync(id);

        return new RfidLogDto
        {
            Id = rfidLog.Id,
            Timestamp = rfidLog.Timestamp,
            ValidatorId = rfidLog.ValidatorId,
            EmployeeId = rfidLog.EmployeeId
        };
    }

    public async Task<IEnumerable<RfidLogDto>> GetAllRfidLogsAsync()
    {
        var rfidLogs = await rfidLogRepository.GetAllRfidLogsAsync();

        return rfidLogs.Select(r =>
            new RfidLogDto
            {
                Id = r.Id,
                Timestamp = r.Timestamp,
                ValidatorId = r.ValidatorId,
                EmployeeId = r.EmployeeId
            });
    }

    public async Task<RfidLogDto> AddRfidLogAsync(RfidLogRequestDto rfidLogDto)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(rfidLogDto.EmployeeId);
        if (employee == null)
            throw new Exception("Employee not found");

        if (employee.ValidatorId != rfidLogDto.ValidatorId)
            throw new Exception("Employee is not assigned to this validator");

        var rfidLog = new RfidLog
        {
            Id = Guid.NewGuid(),
            Timestamp = DateTime.UtcNow,
            ValidatorId = rfidLogDto.ValidatorId,
            EmployeeId = rfidLogDto.EmployeeId,
        };
        
        await rfidLogRepository.AddRfidLogAsync(rfidLog);
        await rfidLogRepository.SaveChangesAsync();

        return new RfidLogDto
        {
            EmployeeId = rfidLog.EmployeeId,
            ValidatorId = rfidLog.ValidatorId,
            Id = rfidLog.Id,
            Timestamp = rfidLog.Timestamp
        };
    }

    public async Task UpdateRfidLog(Guid id, RfidLogUpdateDto rfidLogDto)
    {
        var rfidLog = await rfidLogRepository.GetRfidLogByIdAsync(id);

        if (rfidLog == null)
            throw new Exception("RfidLog not found");

        if (rfidLogDto.Timestamp != null)
            rfidLog.Timestamp = rfidLogDto.Timestamp;
        
        rfidLogRepository.UpdateRfidLog(rfidLog);
        await rfidLogRepository.SaveChangesAsync();
    }

    public async Task DeleteRfidLog(Guid id)
    {
        var rfidLog = await rfidLogRepository.GetRfidLogByIdAsync(id);
        
        rfidLogRepository.DeleteRfidLog(rfidLog);
        await rfidLogRepository.SaveChangesAsync();
    }
}
