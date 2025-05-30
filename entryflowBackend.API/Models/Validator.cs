using System.ComponentModel.DataAnnotations;
namespace entryflowBackend.API.Models;

public class Validator
{
    [Required]
    public required Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string SecretKey { get; set; }

    [Required]
    [MaxLength(30)]
    public required string Name { get; set; }

    public ICollection<Admin>? Admins { get; set; }

    public ICollection<Employee>? Employees { get; set; }

    public ICollection<RfidLog>? RfidLogs { get; set; }
}
