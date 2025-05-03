using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class EmployeeRepository(EntryflowDbContext context) : IEmployeeRepository
{
    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        return employee ?? throw new KeyNotFoundException($"Employee not found");
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await context.Employees.ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await context.Employees.AddAsync(employee ?? throw new ArgumentNullException(nameof(employee)));
    }

    public void UpdateEmployee(Employee employee)
    {
        context.Employees.Update(employee ?? throw new ArgumentNullException(nameof(employee)));
    }

    public void DeleteEmployee(Employee employee)
    {
        context.Employees.Remove(employee ?? throw new ArgumentNullException(nameof(employee)));
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}