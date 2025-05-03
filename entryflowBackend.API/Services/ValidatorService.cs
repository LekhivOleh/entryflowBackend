using entryflowBackend.API.DTOs;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;

namespace entryflowBackend.API.Services;

public class ValidatorService(IValidatorRepository validatorRepository) : IValidatorService
{

    public async Task<ValidatorDto> GetValidatorByIdAsync(Guid id)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(id);
        return new ValidatorDto
        {
            Id = validator.Id,
            SecretKey = validator.SecretKey,
            Name = validator.Name
        };
    }

    public async Task<IEnumerable<ValidatorDto>> GetAllValidatorsAsync()
    {
        var validators = await validatorRepository.GetAllValidatorsAsync();
        return validators.Select(v => new ValidatorDto
        {
            Id = v.Id,
            SecretKey = v.SecretKey,
            Name = v.Name
        });
    }

    public async Task<ValidatorDto> AddValidatorAsync(CreateValidatorDto validatorDto)
    {
        var validator = new Validator
        {
            SecretKey = validatorDto.SecretKey,
            Name = validatorDto.Name
        };

        await validatorRepository.AddValidatorAsync(validator);
        await validatorRepository.SaveChangesAsync();

        return new ValidatorDto
        {
            Id = validator.Id,
            SecretKey = validator.SecretKey,
            Name = validator.Name
        };
    }

    public async Task UpdateValidatorAsync(Guid id, UpdateValidatorDto validatorDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(id);
        validator.Name = validatorDto.Name;

        validatorRepository.UpdateValidator(validator);
        await validatorRepository.SaveChangesAsync();
    }

    public async Task DeleteValidatorAsync(Guid id)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(id);

        validatorRepository.DeleteValidator(validator);
        await validatorRepository.SaveChangesAsync();
    }
}