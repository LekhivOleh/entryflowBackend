namespace entryflowBackend.API.Models;

public class RfidLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required Guid ValidatorId { get; set; }
    public Validator Validator { get; set; }

    public required Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public required DateTime Timestamp { get; set; }
}
