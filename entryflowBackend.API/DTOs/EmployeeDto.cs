using System.ComponentModel.DataAnnotations;

namespace entryflowBackend.API.DTOs;

public class EmployeeDto
{
    [Required]
    public required Guid Id { get; set; }
    
    [Required]
    public required string FirstName { get; set; }
    
    [Required]
    public required string LastName { get; set; }
    
    [Required]
    public required string CardUid { get; set; }
    
    [Required]
    public required Guid ValidatorId { get; set; }
}

public class EmployeeRequestDto
{
    [Required]
    public required string FirstName { get; set; }
    
    [Required]
    public required string LastName { get; set; }
    
    [Required]
    public required string CardUid { get; set; }
    
    [Required]
    public required Guid ValidatorId { get; set; }
}

public class EmployeeUpdateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CardUid { get; set; }
}
