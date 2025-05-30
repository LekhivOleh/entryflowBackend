using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.Repositories;

public class ValidatorRepository(EntryflowDbContext context) : IValidatorRepository
{
    public async Task<Validator> GetValidatorByIdAsync(Guid id)
    {
        var validator = await context
            .Validators
            .SingleOrDefaultAsync(x => x.Id == id);
        return validator ?? throw new KeyNotFoundException("Validator not found");
    }

    public async Task<IEnumerable<Validator>> GetAllValidatorsAsync()
    {
        return await context
            .Validators
            .ToListAsync();
    }

    public async Task AddValidatorAsync(Validator validator)
    {
        await context
            .Validators
            .AddAsync(validator ?? throw new ArgumentNullException(nameof(validator)));
    }

    public void UpdateValidator(Validator validator)
    {
        context
            .Validators
            .Update(validator);
    }

    public void DeleteValidator(Validator validator)
    {
        context
            .Validators
            .Remove(validator);
    }

    public async Task<Validator> GetValidatorBySecretAsync(string? secretKey)
    {
        return await context
            .Validators
            .SingleOrDefaultAsync(v => v.SecretKey == secretKey) ?? throw new ArgumentNullException(nameof(secretKey));
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
