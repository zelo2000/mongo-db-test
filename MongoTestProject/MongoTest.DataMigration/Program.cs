using Microsoft.Extensions.Configuration;
using MongoDBMigrations;
using MongoTest.Core.Configuration;
using System.Reflection;

var configuration = BuildConfiguration();
var databaseSettings = configuration.GetDatabaseSetting();
var connectionString = configuration.GetDatabaseConnectionString();

Console.WriteLine("Migration started...\n");

var result = new MigrationEngine()
    .UseDatabase(connectionString, databaseSettings.MoviesDatabase)
    .UseAssembly(Assembly.GetExecutingAssembly())
    .UseSchemeValidation(false)
    .Run();

Console.WriteLine($"Server address: {result.ServerAdress}");
Console.WriteLine($"Database name: {result.DatabaseName}");
Console.WriteLine($"Latest version: {result.CurrentVersion}\n");

if (result.Success)
{
    foreach (var item in result.InterimSteps)
    {
        Console.WriteLine($"{item.TargetVersion} {item.MigrationName}");
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Migration applied successfully!");
    Console.ForegroundColor = default;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Migration failed!");
    Console.ForegroundColor = default;
}

IConfiguration BuildConfiguration()
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env}.json", true, true)
        .AddUserSecrets(Assembly.GetExecutingAssembly());

    IConfiguration configuration = builder.Build();

    return configuration;
}