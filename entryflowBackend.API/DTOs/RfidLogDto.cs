using System.ComponentModel.DataAnnotations;

namespace entryflowBackend.API.DTOs;

public class RfidLogDto
{
    [Required]
    public required Guid Id { get; set; }
    
    [Required]
    public required Guid ValidatorId { get; set; }

    [Required]
    public required Guid EmployeeId { get; set; }
    
    [Required]
    public required DateTime Timestamp { get; set; }
}

public class RfidLogRequestDto
{
    [Required]
    public required Guid ValidatorId { get; set; }
    
    [Required]
    public required Guid EmployeeId { get; set; }
}

public class RfidLogUpdateDto
{
    [Required]
    public required DateTime Timestamp { get; set; }
}
