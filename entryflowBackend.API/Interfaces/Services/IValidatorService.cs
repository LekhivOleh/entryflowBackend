using entryflowBackend.API.DTOs;

namespace entryflowBackend.API.Interfaces.Services;

public interface IValidatorService
{
    Task<ValidatorDto> GetValidatorByIdAsync(Guid id);
    Task<IEnumerable<ValidatorDto>> GetAllValidatorsAsync();
    Task<ValidatorDto> AddValidatorAsync(CreateValidatorDto validatorDto);
    Task UpdateValidatorAsync(Guid id, UpdateValidatorDto validatorDto);
    Task DeleteValidatorAsync(Guid id);
}