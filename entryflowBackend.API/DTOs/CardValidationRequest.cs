namespace entryflowBackend.API.DTOs;

public class CardValidationRequest
{
    public required string Uid { get; set; } = string.Empty;
    public required string ValidatorSecret { get; set; } = string.Empty;
}
