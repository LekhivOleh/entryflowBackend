using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Repositories;
using entryflowBackend.API.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace entryflowBackend.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<EntryflowDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddScoped<IValidatorRepository, ValidatorRepository>();
        builder.Services.AddScoped<IValidatorService, ValidatorService>();

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();
        
        app.MapOpenApi();

        // Configure the HTTP request pipeline.
        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("Entryflow APi")
                .WithTheme(ScalarTheme.Saturn)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });


        app.MapGet("/", () => "At least it runs");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}