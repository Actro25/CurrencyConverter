using Application.Features.Currencies;
using Application.Features.Currencies.Queries.GetSpecialCurrencyConversionAmount;
using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;
using Application.Features.Currencies.Queries.PullAllCurrencyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrencyProvider
    {
        ProviderType ProviderType { get; }
        public Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default);
        public Task<CurrencyRateDto> GetCertainCurrencyRate(GetSpecialCurrencyRateQuery codes, CancellationToken cancellationToken = default);
        public Task<CurrencyConversionDto> GetCertainCurrencyConversionAmount(GetSpecialCurrencyConversionAmountQuery codes, CancellationToken cancellationToken = default);
    }
}
