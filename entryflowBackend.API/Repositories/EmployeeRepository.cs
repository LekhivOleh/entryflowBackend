using entryflowBackend.API.DbContext;
using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class EmployeeRepository(EntryflowDbContext context) : IEmployeeRepository
{
    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await context.Employees
            .Include(v => v.Validator)
            .FirstOrDefaultAsync(e => e.Id == id);
        return employee ?? throw new KeyNotFoundException($"Employee not found");
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await context.Employees
            .Include(v => v.Validator)
            .ToListAsync();
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

    public async Task<EmployeeDto> GetEmployeeByCardUidAsync(string cardUid)
    {
        var employee = await context
            .Employees
            .Include(v => v.Validator)
            .SingleOrDefaultAsync(e => e.CardUid == cardUid);
        
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(cardUid));
        }
        
        var validator = employee.Validator;
        
        return new EmployeeDto
        {
            Name = employee.Name,
            CardUid = employee.CardUid,
            Validator = new ValidatorDto
            {
                Id = validator.Id,
                Name = validator.Name,
                SecretKey = validator.SecretKey
            }
        };
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}