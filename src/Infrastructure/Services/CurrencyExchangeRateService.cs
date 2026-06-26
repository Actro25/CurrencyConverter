using Application.Common.Interfaces;
using Application.Features.Currencies;
using Application.Features.Currencies.Queries;
using Application.Features.Currencies.Queries.GetSpecialCurrencyConversionAmount;
using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;
using Application.Features.Currencies.Queries.PullAllCurrencyInfo;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class CurrencyExchangeRateService : ICurrencyProvider
    {
        private HttpClient _client;

        public ProviderType ProviderType => throw new NotImplementedException();

        public CurrencyExchangeRateService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrencyRateDto> GetCertainCurrencyRate(GetSpecialCurrencyRateQuery codes, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _client.GetFromJsonAsync<CurrencyRateDto>($"pair/{codes.BaseCode}/{codes.TargetCode}", cancellationToken);
                return response ?? new CurrencyRateDto(codes.BaseCode, codes.TargetCode, default, Status.UNSECCESSFUL);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"EXCHANGE_RATE_API request GetCertainCurrencyRate error: {ex.Message}");
                return new CurrencyRateDto(codes.BaseCode, codes.TargetCode, default, Status.UNSECCESSFUL);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonConvert Error occur in EXCHANGE_RATE_API request GetCertainCurrencyRate error: {ex.Message}");
                return new CurrencyRateDto(codes.BaseCode, codes.TargetCode, default, Status.UNSECCESSFUL);
            }
        }

        public async Task<CurrencyConversionDto> GetCertainCurrencyConversionAmount(GetSpecialCurrencyConversionAmountQuery codes, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _client.GetFromJsonAsync<CurrencyConversionDto>($"pair/{codes.BaseCode}/{codes.TargetCode}", cancellationToken);
                return response ?? new CurrencyConversionDto(codes.BaseCode, codes.TargetCode, 0.0M, 0.0M, Status.UNSECCESSFUL);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"EXCHANGE_RATE_API request GetCertainCurrencyConversionAmount error: {ex.Message}");
                return new CurrencyConversionDto(codes.BaseCode, codes.TargetCode, 0.0M, 0.0M, Status.UNSECCESSFUL);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonConvert Error occur in EXCHANGE_RATE_API request GetCertainCurrencyConversionAmount error: {ex.Message}");
                return new CurrencyConversionDto(codes.BaseCode, codes.TargetCode, 0.0M, 0.0M, Status.UNSECCESSFUL);
            }
        }

        public Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
