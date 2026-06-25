using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string CF_API, string CER_API)
        {
            services.AddHttpClient<ICurrencyFreaksService, CurrencyFreaksService>(client =>
            {
                client.BaseAddress = new Uri("https://api.currencyfreaks.com/");
                client.Timeout = TimeSpan.FromSeconds(15);
            });
            services.AddHttpClient<ICurrencyExchangeRateService, CurrencyExchangeRateService>(client =>
            {
                client.BaseAddress = new Uri($"https://v6.exchangerate-api.com/v6/{CER_API}/");
                client.Timeout = TimeSpan.FromSeconds(15);
            });
            return services;
        }
    }
}
