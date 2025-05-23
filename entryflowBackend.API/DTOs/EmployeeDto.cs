namespace entryflowBackend.API.DTOs;

public record EmployeeDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string CardUid { get; set; }
    public required ValidatorDto Validator { get; set; }
}