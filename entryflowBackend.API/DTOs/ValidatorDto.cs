namespace entryflowBackend.API.DTOs;

public class ValidatorDto
{
    public required Guid Id { get; set; }
    public required string SecretKey { get; set; }
    public required string Name { get; set;}
}

public class ValidatorRequestDto
{
    public required string SecretKey { get; set; }
    public required string Name { get; set;}
}