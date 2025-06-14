using entryflowBackend.API.DTOs;
using entryflowBackend.API.Models;

namespace entryflowBackend.API.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<IEnumerable<Employee>> GetAllEmployeesByAdminAsync(AdminDto admin);
    Task AddEmployeeAsync(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(Employee employee);
    Task<Employee> GetEmployeeByCardUidAsync(string cardUid);
    Task SaveChangesAsync();
}