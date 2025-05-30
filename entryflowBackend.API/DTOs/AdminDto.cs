using System.ComponentModel.DataAnnotations;

namespace entryflowBackend.API.DTOs;

public class AdminDto
{
    public Guid Id { get; set; }
    
    [Required]
    public required string FirstName { get; set; }
    
    [Required]
    public required string LastName { get; set; }
    
    [Required]
    public required string Email { get; set; }
    
    [Required]
    public required Guid ValidatorId { get; set; }
    
    [Required]
    public required ValidatorDto Validator { get; set; }
}

public class AdminRequestDto
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    
    public required string Password { get; set; }
    
    public required Guid ValidatorId { get; set; }
}

public class AdminUpdateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
