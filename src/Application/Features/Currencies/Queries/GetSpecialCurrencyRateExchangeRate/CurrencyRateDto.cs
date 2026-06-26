using System.Text.Json.Serialization;

namespace Application.Features.Currencies.Queries.GetSpecialCurrencyRate
{
    public record CurrencyRateDto(
        [property: JsonPropertyName("base_code")][property: JsonRequired()] string BaseCode,
        [property: JsonPropertyName("target_code")][property: JsonRequired()] string TargetCode,
        [property: JsonPropertyName("conversion_rate")][property: JsonRequired()] decimal ConversionRate,
        Status Status
        );
}
