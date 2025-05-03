using entryflowBackend.API.Models;

namespace entryflowBackend.API.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(Employee employee);
    Task SaveChangesAsync();
}