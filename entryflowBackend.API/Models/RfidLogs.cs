namespace entryflowBackend.API.Models;

public class RfidLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required Guid ValidatorId { get; set; }
    public required Validator Validator { get; set; }

    public required Guid EmployeeId { get; set; }
    public required Employee Employee { get; set; }
    
    public required DateTime Timestamp { get; set; }
}
