using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Currencies.Queries.PullAllCurrencyInfo
{
    public record CurrencyInfoDto(
        [property: JsonPropertyName("currencyCode")][property: JsonRequired()] string CurrencyCode,
        [property: JsonPropertyName("currencyName")][property: JsonRequired()] string CurrencyName,
        [property: JsonPropertyName("countryCode")][property: JsonRequired()] string CountryCode,
        [property: JsonPropertyName("countryName")][property: JsonRequired()] string CountryName,
        [property: JsonConverter(typeof(JsonStringEnumConverter))][property: JsonPropertyName("status")][property: JsonRequired()] Status Status,
        [property: JsonPropertyName("icon")][property: JsonRequired()] string Icon);
}
