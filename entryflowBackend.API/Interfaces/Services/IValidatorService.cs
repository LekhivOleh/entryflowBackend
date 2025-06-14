using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IValidatorService
{
    Task<ValidatorDto> GetValidatorByIdAsync(Guid id);
    Task<IEnumerable<ValidatorDto>> GetAllValidatorsAsync();
    Task<ValidatorDto> AddValidatorAsync(ValidatorRequestDto validatorRequestDto);
    Task UpdateValidatorAsync(Guid id, ValidatorUpdateDto validatorDto);
    Task DeleteValidatorAsync(Guid id);
    Task<ValidatorDto?> GetValidatorBySecretAsync(string secret);
}