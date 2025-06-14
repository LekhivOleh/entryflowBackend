using System.Text.Json.Serialization;

namespace entryflowBackend.API.DTOs;


public class CardValidationRequest
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("validatorSecret")]
    public string ValidatorSecret { get; set; }
}
