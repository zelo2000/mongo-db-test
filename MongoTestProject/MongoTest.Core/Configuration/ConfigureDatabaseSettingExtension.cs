using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoTest.Core.Configuration.Models;

namespace MongoTest.Core.Configuration
{
    public static class ConfigureDatabaseSettingExtension
    {
        public static DatabaseSettings ConfigureDatabaseSetting(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("DatabaseSettings");
            services.Configure<DatabaseSettings>(section);
            return section.Get<DatabaseSettings>();
        }

        public static DatabaseSettings GetDatabaseSetting(this IConfiguration configuration) => configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
        public static string GetDatabaseConnectionString(this IConfiguration configuration) => configuration.GetConnectionString("MoviesCluster");
    }
}
