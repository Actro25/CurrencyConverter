using System.Text.Json.Serialization;

namespace Application.Features.Currencies.Queries.PullAllCurrencyInfo
{
    public record CurrencyInfoDto(
        [property: JsonPropertyName("currencyCode")][property: JsonRequired()] string CurrencyCode,
        [property: JsonPropertyName("currencyName")][property: JsonRequired()] string CurrencyName,
        [property: JsonPropertyName("countryCode")][property: JsonRequired()] string CountryCode,
        [property: JsonPropertyName("countryName")][property: JsonRequired()] string CountryName,
        [property: JsonPropertyName("icon")][property: JsonRequired()] string Icon);
}
