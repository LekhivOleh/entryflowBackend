using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class EmployeeRepository(EntryflowDbContext context) : IEmployeeRepository
{
    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await context.Employees
            .Include(e => e.Validator)
            .FirstOrDefaultAsync(e => e.Id == id);
        return employee ?? throw new KeyNotFoundException($"Employee not found");
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var employees = await context
            .Employees
            .Include(e => e.Validator)
            .ToListAsync();
        return employees;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await context
            .Employees
            .AddAsync(employee ?? throw new ArgumentNullException(nameof(employee)));
    }

    public void UpdateEmployee(Employee employee)
    {
        context
            .Employees
            .Update(employee ?? throw new ArgumentNullException(nameof(employee)));
    }

    public void DeleteEmployee(Employee employee)
    {
        context
            .Employees
            .Remove(employee ?? throw new ArgumentNullException(nameof(employee)));
    }

    public async Task<Employee> GetEmployeeByCardUidAsync(string cardUid)
    {
        var employee = await context
            .Employees
            .Include(e => e.Validator)
            .SingleOrDefaultAsync(e => e.CardUid == cardUid);

        if (employee == null)
        {
            throw new ArgumentNullException(nameof(cardUid));
        }

        return employee;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
