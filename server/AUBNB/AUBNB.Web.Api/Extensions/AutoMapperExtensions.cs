using AUBNB.Infra.Extensions;
using AUBNB.Web.Api;
using Microsoft.Extensions.DependencyInjection;

namespace AUBNB.Web.API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.ConfigureProfiles(typeof(Startup));
        }
    }
}
