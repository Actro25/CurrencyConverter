using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddTransient<ICurrencyFreaksService>();
            services.AddTransient<ICurrencyExchangeRateService>();
            return services;
        }
    }
}
