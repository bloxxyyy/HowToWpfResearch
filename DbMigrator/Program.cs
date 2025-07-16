using Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) => {

        string password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? throw new Exception("Enviroment not set for database!");
        string database = Environment.GetEnvironmentVariable("DB_NAME")     ?? throw new Exception("Enviroment not set for database!");
        string user     = Environment.GetEnvironmentVariable("DB_USER")     ?? throw new Exception("Enviroment not set for database!");

        string connectionString = $"Server=localhost,1433;Database={database};User Id={user};Password={password};TrustServerCertificate=True";

        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure()));
        })

    .Build();

using IServiceScope scope = host.Services.CreateScope();
DatabaseContext db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

Console.WriteLine("Applying migrations...");
await db.Database.MigrateAsync();
Console.WriteLine("Done.");
