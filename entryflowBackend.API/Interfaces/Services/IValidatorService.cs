using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IValidatorService
{
    Task<ValidatorDto> GetValidatorByIdAsync(Guid id);
    Task<IEnumerable<ValidatorDto>> GetAllValidatorsAsync();
    Task<ValidatorDto> AddValidatorAsync(ValidatorRequestDto validatorRequestDto);
    Task UpdateValidatorAsync(Guid id, ValidatorRequestDto validatorDto);
    Task DeleteValidatorAsync(Guid id);
    Task<ValidatorDto> GetValidatorBySecretAsync(string secretKey);
}