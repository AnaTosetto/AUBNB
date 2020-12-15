using AUBNB.Application.Features.Hostings;
using AUBNB.Application.Features.Users;
using AUBNB.Domain.Features.Hostings;
using AUBNB.Domain.Features.Users;
using AUBNB.Infra.Data.Contexts;
using AUBNB.Infra.Data.Features.Hostings;
using AUBNB.Infra.Data.Features.Users;
using Microsoft.Extensions.DependencyInjection;

namespace AUBNB.Web.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<AUBNBDbContext>();

            AddUserFeature(services);
            AddHostingFeature(services);
        }

        private static void AddUserFeature(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddHostingFeature(IServiceCollection services)
        {
            services.AddScoped<IHostingService, HostingService>();
            services.AddScoped<IHostingRepository, HostingRepository>();
        }
    }
}
