namespace entryflowBackend.API.DTOs;

public record ValidatorDto
{
    public Guid Id { get; set; }
    public string SecretKey { get; set; }
    public string Name { get; set;}
}

public record CreateValidatorDto
{
    public string SecretKey {get; set;}
    public string Name { get; set;}
}

public record UpdateValidatorDto
{
    public string Name { get; set;}
}