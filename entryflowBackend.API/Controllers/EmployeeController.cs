using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet("{id}", Name = "GetEmployeeById")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        try
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpGet(Name = "GetAllEmployees")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpPost(Name = "AddEmployee")]
    public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
    {
        try
        {
            var employee = await employeeService.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(AddEmployee), new { id = employee.Id }, employee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("{id}", Name = "UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeDto employeeDto)
    {
        await employeeService.UpdateEmployeeAsync(id, employeeDto);
        return NoContent();
    }
    
    [HttpDelete("{id}", Name = "DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        await employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }
}