using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entryflowBackend.API.Models;

public class RfidLog
{
    [Required]
    public required Guid Id { get; set; }
    
    [Required]
    public required Guid ValidatorId { get; set; }
    [ForeignKey("ValidatorId")]
    public Validator? Validator { get; set; }

    [Required]
    public required Guid EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }
    
    [Required]
    public required DateTime Timestamp { get; set; }
}
