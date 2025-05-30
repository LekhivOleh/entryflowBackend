using System.ComponentModel.DataAnnotations;
namespace entryflowBackend.API.DTOs;

public class ValidatorDto
{
    public required Guid Id { get; set; }
    [Required]
    public required string Name { get; set;}
}

public class ValidatorRequestDto
{
    [Required]
    public required string Name { get; set;}
    [Required]
    public required string SecretKey { get; set; }
}

public class ValidatorUpdateDto
{
    [Required]
    public required string Name { get; set;}
    [Required]
    public required string SecretKey { get; set; }
}
