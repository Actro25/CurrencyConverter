using Application.Common.Interfaces;
using Application.Features.Currencies;
using Infrastructure.Services;

namespace Infrastructure.Services
{
    public class CurrencyInfoServiceTest
    {
        [Fact]
        public async Task GetAllCurreencyInfoAsync_NothingGiven_ReturnsThreeCurrencyInfoDtoAsync() {
            ICurrencyInfoService currencyService = new CurrencyInfoService();
            var expectedData = new List<CurrencyInfoDto> {
                new CurrencyInfoDto("PKR", "Pakistan Rupee", "PK","Pakistan", Status.Available,"https://currencyfreaks.com/photos/flags/btc.png?v=0.1"),
                new CurrencyInfoDto("BTC", "Bitcoin", "Crypto","Global", Status.Available, "https://currencyfreaks.com/photos/flags/btc.png?v=0.1"),
                new CurrencyInfoDto("XPT", "Platinum", "Metal","Global", Status.Available, "https://currencyfreaks.com/photos/flags/xpt.png?v=0.1"),
            };

            var data = await currencyService.GetAllCurreencyInfoAsync();

            Assert.Equivalent(expectedData,data);
        } 
    }
}
