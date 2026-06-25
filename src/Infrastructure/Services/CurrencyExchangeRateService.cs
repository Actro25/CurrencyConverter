using Application.Common.Interfaces;
using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class CurrencyExchangeRateService : ICurrencyExchangeRateService
    {
        private HttpClient _client;

        public CurrencyExchangeRateService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrencyRateDto> GetCertainCurrencyRate(GetSpecialCurrencyRateQuery codes, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _client.GetFromJsonAsync<CurrencyRateDto>($"pair/{codes.base_code}/{codes.target_code}", cancellationToken);
                return response ?? new CurrencyRateDto(codes.base_code, codes.target_code, default, Application.Features.Currencies.Queries.GetSpecialCurrencyRate.Status.UNSECCESSFUL);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"EXCHANGE_RATE_API request error: {ex.Message}");
                return new CurrencyRateDto(codes.base_code, codes.target_code, default, Application.Features.Currencies.Queries.GetSpecialCurrencyRate.Status.UNSECCESSFUL);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonConvert Error occur in EXCHANGE_RATE_API error: {ex.Message}");
                return new CurrencyRateDto(codes.base_code, codes.target_code, default, Application.Features.Currencies.Queries.GetSpecialCurrencyRate.Status.UNSECCESSFUL);
            }
        }
    }
}
