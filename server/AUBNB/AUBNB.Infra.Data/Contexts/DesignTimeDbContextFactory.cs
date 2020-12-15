using AUBNB.Infra.Settings;
using AUBNB.Infra.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AUBNB.Infra.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AUBNBDbContext>
    {
        public AUBNBDbContext CreateDbContext(string[] args)
        {
            var configEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{configEnvironment}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AUBNBDbContext>();

            var settings = config.LoadSettings<AppSettings>("AppSettings");

            optionsBuilder.UseSqlServer(settings.ConnectionString);

            return new AUBNBDbContext(optionsBuilder.Options);
        }
    }
}
