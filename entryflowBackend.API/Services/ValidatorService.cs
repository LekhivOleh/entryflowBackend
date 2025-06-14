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
            Name = validator.Name
        };
    }

    public async Task<IEnumerable<ValidatorDto>> GetAllValidatorsAsync()
    {
        var validators = await validatorRepository.GetAllValidatorsAsync();
        return validators.Select(v => new ValidatorDto
        {
            Id = v.Id,
            Name = v.Name
        });
    }

    public async Task<ValidatorDto> AddValidatorAsync(ValidatorRequestDto validatorRequestDto)
    {
        var validator = new Validator
        {
            Id = Guid.NewGuid(),
            SecretKey = validatorRequestDto.SecretKey,
            Name = validatorRequestDto.Name
        };

        await validatorRepository.AddValidatorAsync(validator);
        await validatorRepository.SaveChangesAsync();

        return new ValidatorDto
        {
            Id = validator.Id,
            Name = validator.Name
        };
    }

    public async Task UpdateValidatorAsync(Guid id, ValidatorUpdateDto validatorDto)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(id);
        if (!string.IsNullOrWhiteSpace(validatorDto.Name))
            validator.Name = validatorDto.Name;
        if (!string.IsNullOrWhiteSpace(validatorDto.SecretKey))
            validator.SecretKey = validatorDto.SecretKey;

        validatorRepository.UpdateValidator(validator);
        await validatorRepository.SaveChangesAsync();
    }

    public async Task DeleteValidatorAsync(Guid id)
    {
        var validator = await validatorRepository.GetValidatorByIdAsync(id);

        validatorRepository.DeleteValidator(validator);
        await validatorRepository.SaveChangesAsync();
    }

    public async Task<ValidatorDto?> GetValidatorBySecretAsync(string secret)
    {
        var validator = await validatorRepository.GetValidatorBySecretAsync(secret);
        if (validator == null) return null;
        return new ValidatorDto
        {
            Id = validator.Id,
            Name = validator.Name
        };
    }
}