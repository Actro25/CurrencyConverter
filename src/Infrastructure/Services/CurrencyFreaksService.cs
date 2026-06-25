using Application.Common.Interfaces;
using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;
using Application.Features.Currencies.Queries.PullAllCurrencyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
