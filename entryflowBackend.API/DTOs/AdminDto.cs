namespace entryflowBackend.API.DTOs;

public record AdminDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required ValidatorBriefDto Validator { get; set; }
}

public record CreateAdminDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public Guid ValidatorId { get; set; }
}

public record UpdateAdminDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public record ValidatorBriefDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}