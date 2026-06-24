using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddHttpClient<ICurrencyInfoService, CurrencyInfoService>(client => {
                client.BaseAddress = new Uri("https://api.currencyfreaks.com/");
                client.Timeout = TimeSpan.FromSeconds(15);
            });
            return services;
        }
    }
}
