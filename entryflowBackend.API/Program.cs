using entryflowBackend.API.DbContext;
using entryflowBackend.API.Interfaces.Repositories;
using entryflowBackend.API.Interfaces.Services;
using entryflowBackend.API.Models;
using entryflowBackend.API.Repositories;
using entryflowBackend.API.Services;
using Microsoft.AspNetCore.Identity;
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
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IRfidLogRepository, RfidLogRepository>();
        builder.Services.AddScoped<IRfidLogService, RfidLogService>();

        builder.Services.AddScoped<IPasswordHasher<Admin>, PasswordHasher<Admin>>();

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });

        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapOpenApi();

        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("Entryflow APi")
                .WithTheme(ScalarTheme.Saturn)
                .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.HttpClient);
        });

        app.MapGet("/", () => "At least it runs");

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
