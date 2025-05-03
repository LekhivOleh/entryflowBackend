namespace entryflowBackend.API.Models;
public class Admin
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public Guid ValidatorId { get; set; }
    public Validator Validator { get; set; }

}
