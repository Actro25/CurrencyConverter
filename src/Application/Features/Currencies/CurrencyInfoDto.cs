using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Currencies
{
    public record CurrencyInfoDto(
        [property: JsonPropertyName("currencyCode")] string currencyCode,
        [property: JsonPropertyName("currencyName")] string currencyName,
        [property: JsonPropertyName("countryCode")] string countryCode,
        [property: JsonPropertyName("countryName")] string countryName,
        [property: JsonConverter(typeof(JsonStringEnumConverter))] [property: JsonPropertyName("status")] Status status,
        [property: JsonPropertyName("icon")] string icon);
}
