namespace entryflowBackend.API.DTOs;

public record ValidatorDto
{
    public required Guid Id { get; set; }
    public required string SecretKey { get; set; }
    public required string Name { get; set;}
}

public record CreateValidatorDto
{
    public required string SecretKey {get; set;}
    public required string Name { get; set;}
}

public record UpdateValidatorDto
{
    public required string Name { get; set;}
}