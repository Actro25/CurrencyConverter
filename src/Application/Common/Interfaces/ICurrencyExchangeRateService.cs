using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;

namespace Application.Common.Interfaces
{
    public interface ICurrencyExchangeRateService
    {
        public Task<CurrencyRateDto> GetCertainCurrencyRate(GetSpecialCurrencyRateQuery codes, CancellationToken cancellationToken = default);
    }
}
