using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Currencies
{
    public record CurrencyInfoDto(string currencyCode, string currencyName, string countryCode, string countryName, Status status, string icon);
}
