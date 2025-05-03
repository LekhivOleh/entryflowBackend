namespace entryflowBackend.API.DTOs;

public record AdminDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Guid ValidatorId { get; set; }
}

public record CreateAdminDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Guid ValidatorId { get; set; }
}

public record UpdateAdminDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Guid? ValidatorId { get; set; }
}