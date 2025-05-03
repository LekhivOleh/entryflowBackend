using entryflowBackend.API.Models;

namespace entryflowBackend.API.Interfaces.Repositories;

public interface IValidatorRepository
{
    Task<Validator> GetValidatorByIdAsync(Guid id);
    Task<IEnumerable<Validator>> GetAllValidatorsAsync();
    Task AddValidatorAsync(Validator validator);
    void UpdateValidator(Validator validator);
    void DeleteValidator(Validator validator);
    Task SaveChangesAsync();
}