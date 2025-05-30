using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entryflowBackend.API.Models;
public class Admin
{
    [Required]
    public required Guid Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string FirstName { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string LastName { get; set; }
    
    [Required]
    [MaxLength(320)]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }

    [Required]
    public required Guid ValidatorId { get; set; }
    
    [ForeignKey("ValidatorId")]
    public Validator? Validator { get; set; }
}
