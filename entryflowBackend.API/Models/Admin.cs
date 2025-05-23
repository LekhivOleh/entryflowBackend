using System.ComponentModel.DataAnnotations;
namespace entryflowBackend.API.Models;
public class Admin
{
    public required Guid Id { get; set; }

    [MaxLength(20)]
    public required string FirstName { get; set; }
    
    [MaxLength(20)]
    public required string LastName { get; set; }
    
    [MaxLength(320)]
    public required string Email { get; set; }
    
    [MaxLength(50)]
    public required string Password { get; set; }

    public required Guid ValidatorId { get; set; }
    public Validator Validator { get; set; }
}
