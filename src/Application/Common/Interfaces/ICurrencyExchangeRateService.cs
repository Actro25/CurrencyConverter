using Application.Features.Currencies.Queries.GetSpecialCurrencyConversionAmount;
using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;

namespace Application.Common.Interfaces
{
    public interface ICurrencyExchangeRateService
    {
        public Task<CurrencyRateDto> GetCertainCurrencyRate(GetSpecialCurrencyRateQuery codes, CancellationToken cancellationToken = default);

        public Task<CurrencyConversionDto> GetCertainCurrencyConversionAmount(GetSpecialCurrencyConversionAmountQuery codes, CancellationToken cancellationToken = default);
    }
}
