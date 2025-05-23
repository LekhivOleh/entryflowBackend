using System.ComponentModel.DataAnnotations;

namespace entryflowBackend.API.Models;

public class Validator
{
    public required Guid Id { get; set; }

    [MaxLength(50)] public required string SecretKey { get; set; }

    [MaxLength(50)] public required string Name { get; set; }

    public ICollection<Admin> Admins { get; set; }

    public ICollection<Employee> Employees { get; set; }

    public ICollection<RfidLog> RfidLogs { get; set; }
}