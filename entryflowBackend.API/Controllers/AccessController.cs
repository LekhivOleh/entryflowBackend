using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;
using entryflowBackend.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace entryflowBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccessController(
    IValidatorService validatorService, 
    IEmployeeService employeeService,
    IRfidLogService rfidLogService
    ) : ControllerBase
{
    [HttpPost("validate")]
    public async Task<IActionResult> ValidateCard([FromBody] CardValidationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ValidatorSecret))
            return BadRequest("Validator secret is required.");
        if (string.IsNullOrWhiteSpace(request.Uid))
            return BadRequest("Card UID is required.");

        var validator = await validatorService.GetValidatorBySecretAsync(request.ValidatorSecret);
        if (validator == null)
            return BadRequest("denied");

        var employee = await employeeService.GetEmployeeByCardUidAsync(request.Uid);
        if (employee == null || employee.ValidatorId != validator.Id)
            return BadRequest("denied");

        var rfidLog = new RfidLogRequestDto
        {
            ValidatorId = validator.Id,
            EmployeeId = employee.Id
        };
        await rfidLogService.AddRfidLogAsync(rfidLog);

        return Ok("granted");
    }
}
