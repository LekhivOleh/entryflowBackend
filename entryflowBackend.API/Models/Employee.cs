using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entryflowBackend.API.Models;

public class Employee
{
    [Required]
    public required Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    [Required]
    [MaxLength(8)]
    public required string CardUid { get; set; }

    [Required]
    public required Guid ValidatorId { get; set; }
    [ForeignKey("ValidatorId")]
    public Validator? Validator { get; set; }

    public ICollection<RfidLog>? RfidLogs { get; set; }
}
