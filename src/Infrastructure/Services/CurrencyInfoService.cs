using Application.Common.Interfaces;
using Application.Features.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrencyInfoService : ICurrencyInfoService
    {
        private HttpClient _client;
        public CurrencyInfoService(HttpClient client)
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
                Console.WriteLine($"API request error: {ex.Message}");
                return new List<CurrencyInfoDto>();
            }
        }
    }
}
