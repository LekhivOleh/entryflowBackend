using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> AddEmployeeAsync(EmployeeDto createEmployeeDto);
    Task UpdateEmployeeAsync(Guid id, EmployeeDto updateEmployeeDto);
    Task DeleteEmployeeAsync(Guid id);
    Task<EmployeeDto> GetEmployeeByCardUidAsync(string cardUid);
}