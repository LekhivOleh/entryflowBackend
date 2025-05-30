using System.ComponentModel.DataAnnotations;

namespace entryflowBackend.API.Models;

public class RfidLog
{
    public Guid Id { get; set; }
    
    public Guid ValidatorId { get; set; }
    public Validator Validator { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    [Required]
    public required DateTime Timestamp { get; set; }
}
