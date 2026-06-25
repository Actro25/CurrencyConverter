using Application.Common.Interfaces;
using Application.Features.Currencies.Queries.PullAllCurrencyInfo;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class CurrencyFreaksService : ICurrencyFreaksService
    {
        private HttpClient _client;
        public CurrencyFreaksService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _client.GetFromJsonAsync<List<CurrencyInfoDto>>("v2.0/supported-currencies", cancellationToken);
                return response ?? new List<CurrencyInfoDto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"FREAKS_API request error: {ex.Message}");
                return new List<CurrencyInfoDto>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonConvert Error occur in FREAKS_API error: {ex.Message}");
                return new List<CurrencyInfoDto>();
            }
        }
    }
}
