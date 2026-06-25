using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrencyExchangeRateService
    {
        public Task<CurrencyRateDto> GetCertainCurrencyRate(GetSpecialCurrencyRateQuery codes, CancellationToken cancellationToken = default);
    }
}
