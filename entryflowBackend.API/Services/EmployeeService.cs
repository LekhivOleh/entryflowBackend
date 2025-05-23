using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;

namespace entryflowBackend.API.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IValidatorRepository validatorRepository) : IEmployeeService
{
    public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);
        var validator = employee.Validator;

        if (validator == null)
        {
            throw new Exception("Validator not found");
        }

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

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await employeeRepository.GetAllEmployeesAsync();

        return employees.Select(e =>
            new EmployeeDto
            {
                Name = e.Name,
                CardUid = e.CardUid,
                Validator = new ValidatorDto
                {
                    Id = e.Validator.Id,
                    Name = e.Validator.Name,
                    SecretKey = e.Validator.SecretKey
                }
            });
    }

    public async Task<EmployeeDto> AddEmployeeAsync(EmployeeDto createEmployeeDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(createEmployeeDto.Validator.Id);

        var employee = new Employee
        {
            Name = createEmployeeDto.Name,
            CardUid = createEmployeeDto.CardUid,
            Validator = new Validator
            {
                Id = validator.Id,
                Name = validator.Name,
                SecretKey = validator.SecretKey
            }
        };

        await employeeRepository.AddEmployeeAsync(employee);
        await employeeRepository.SaveChangesAsync();

        return new EmployeeDto
        {
            Name = employee.Name,
            CardUid = employee.CardUid,
            Validator = new ValidatorDto
            {
                Id = employee.Validator.Id,
                Name = employee.Validator.Name,
                SecretKey = employee.Validator.SecretKey
            }
        };
    }

    public async Task UpdateEmployeeAsync(Guid id, EmployeeDto updateEmployeeDto)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);
        
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
        var validator = employee.Validator;
        
        if (validator == null)
        {
            throw new Exception("Validator not found");
        }

        return new EmployeeDto()
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
}