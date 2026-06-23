using Application.Common.Interfaces;
using Application.Features.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrencyInfoService : ICurrencyInfoService
    {
        public Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new List<CurrencyInfoDto> {
                new CurrencyInfoDto("PKR", "Pakistan Rupee", "PK","Pakistan", Status.Available,"https://currencyfreaks.com/photos/flags/btc.png?v=0.1"),
                new CurrencyInfoDto("BTC", "Bitcoin", "Crypto","Global", Status.Available, "https://currencyfreaks.com/photos/flags/btc.png?v=0.1"),
                new CurrencyInfoDto("XPT", "Platinum", "Metal","Global", Status.Available, "https://currencyfreaks.com/photos/flags/xpt.png?v=0.1"),
            });
        }
    }
}
