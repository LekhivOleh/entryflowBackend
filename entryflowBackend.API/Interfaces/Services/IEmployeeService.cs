using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> AddEmployeeAsync(EmployeeRequestDto createEmployeeDto);
    Task UpdateEmployeeAsync(Guid id, EmployeeUpdateDto updateEmployeeDto);
    Task DeleteEmployeeAsync(Guid id);
    Task<EmployeeDto> GetEmployeeByCardUidAsync(string cardUid);
}