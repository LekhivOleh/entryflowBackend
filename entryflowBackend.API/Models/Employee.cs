namespace entryflowBackend.API.Models;

public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required string CardUid { get; set; } // From RFID

    public Guid ValidatorId { get; set; }
    public Validator Validator { get; set; }

    public ICollection<RfidLog> RfidLogs { get; set; }
}
