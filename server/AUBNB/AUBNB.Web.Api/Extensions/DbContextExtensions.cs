using AUBNB.Infra.Settings;
using AUBNB.Infra.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AUBNB.Web.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection UseDbContext<T>(this IServiceCollection service, IConfiguration configuration) where T : DbContext
        {
            // Ainda precisamos registrar uma instância do nosso contexto default, pois o mediator precisa dessa instância para resolver os handlers
            // porém não aplicamos a migração com esta connection string, dessa forma o banco não é criado. 
            var settings = configuration.LoadSettings<AppSettings>("AppSettings", service);
            service.AddDbContext<T>(options => options.UseSqlServer(settings.ConnectionString));

            return service;
        }
    }
}
