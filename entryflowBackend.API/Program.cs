using Scalar.AspNetCore;

namespace entryflowBackend.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference();
        }

        app.MapGet("/", () => "At least it runs");

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}