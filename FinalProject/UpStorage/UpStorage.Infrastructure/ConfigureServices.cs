using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpStorage.Domain.Common.Interfaces;
using UpStorage.Infrastructure.Services;

namespace UpStorage.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, string wwwrootPath)
        {


            services.AddSingleton<IEmailService, EmailManager>();


            return services;
        }
    }
}
