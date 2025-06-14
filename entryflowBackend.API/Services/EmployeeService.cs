using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace entryflowBackend.API.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IValidatorRepository validatorRepository, IAdminService adminService) : IEmployeeService
{
    public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            CardUid = employee.CardUid,
            ValidatorId = employee.ValidatorId
        };
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await employeeRepository.GetAllEmployeesAsync();

        return employees.Select(e =>
            new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CardUid = e.CardUid,
                ValidatorId = e.ValidatorId
            });
    }
    
    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByAdminAsync(string email)
    {
        var admin = await adminService.GetAdminByEmailAsync(email);
        if (admin == null)
            throw new Exception("Admin not found");
        var employees = await employeeRepository.GetAllEmployeesByAdminAsync(admin);

        return employees.Select(e =>
            new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CardUid = e.CardUid,
                ValidatorId = e.ValidatorId
            });
    }

    public async Task<EmployeeDto> AddEmployeeAsync(EmployeeRequestDto employeeDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(employeeDto.ValidatorId);

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            CardUid = employeeDto.CardUid,
            ValidatorId = employeeDto.ValidatorId,
        };

        await employeeRepository.AddEmployeeAsync(employee);
        await employeeRepository.SaveChangesAsync();

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            CardUid = employee.CardUid,
            ValidatorId = employee.ValidatorId,
        };
    }

    public async Task UpdateEmployeeAsync(Guid id, EmployeeUpdateDto employeeDto)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);

        if (employee == null)
        {
            throw new Exception("Employee not found");
        }
        
        if (!string.IsNullOrEmpty(employeeDto.FirstName))
            employee.FirstName = employeeDto.FirstName;
        if (!string.IsNullOrEmpty(employeeDto.LastName))
            employee.LastName = employeeDto.LastName;
        if (!string.IsNullOrEmpty(employeeDto.CardUid))
            employee.CardUid = employeeDto.CardUid;
        
        employeeRepository.UpdateEmployee(employee);
        await employeeRepository.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);
        
        employeeRepository.DeleteEmployee(employee);
        await employeeRepository.SaveChangesAsync();
    }

    public async Task<EmployeeDto> GetEmployeeByCardUidAsync(string cardUid)
    {
        var employee = await employeeRepository.GetEmployeeByCardUidAsync(cardUid);

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            CardUid = employee.CardUid,
            ValidatorId = employee.ValidatorId
        };
    }
}
