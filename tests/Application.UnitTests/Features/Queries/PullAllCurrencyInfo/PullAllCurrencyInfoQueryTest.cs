using Application.Common.Interfaces;
using Application.Features.Currencies;
using Application.Features.Currencies.Queries.PullAllCurrencyInfo;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Features.Queries.PullAllCurrencyInfo
{
    public class PullAllCurrencyInfoQueryTest
    {
        private readonly ICurrencyInfoService _serviceCurrency = Substitute.For<ICurrencyInfoService>();

        [Fact]
        public async Task mediateR_NothingInput_ReturnsCorrectData() {
            PullAllCurrencyInfoQueryHandler pullData = new PullAllCurrencyInfoQueryHandler(_serviceCurrency);
            PullAllCurrencyInfoQuery inputData = new PullAllCurrencyInfoQuery();
            CancellationToken cancelToken = new CancellationToken();

            List<CurrencyInfoDto> expectedData = new List<CurrencyInfoDto> {
                new CurrencyInfoDto("PKR", "Pakistan Rupee", "PK","Pakistan", Status.AVAILABLE,"https://currencyfreaks.com/photos/flags/btc.png?v=0.1"),
                new CurrencyInfoDto("BTC", "Bitcoin", "Crypto","Global", Status.AVAILABLE, "https://currencyfreaks.com/photos/flags/btc.png?v=0.1"),
                new CurrencyInfoDto("XPT", "Platinum", "Metal","Global", Status.AVAILABLE, "https://currencyfreaks.com/photos/flags/xpt.png?v=0.1"),
            };

            pullData.Handle(inputData, cancelToken).Returns(expectedData);

            var data = await pullData.Handle(inputData, cancelToken);

            Assert.Equivalent(expectedData, data);
        }
    }
}
