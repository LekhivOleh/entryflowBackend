using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors]
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
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet(Name = "GetAllEmployees")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpPost(Name = "AddEmployee")]
    public async Task<IActionResult> AddEmployee(EmployeeRequestDto employeeDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = await employeeService.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("{id}", Name = "UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeUpdateDto employeeDto)
    {
        try
        {
            await employeeService.UpdateEmployeeAsync(id, employeeDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id}", Name = "DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        try
        {
            await employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
