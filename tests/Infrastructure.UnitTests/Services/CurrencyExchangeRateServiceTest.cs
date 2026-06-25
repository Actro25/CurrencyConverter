using System.Net;
using Infrastructure.Services;
using Application.Features.Currencies.Queries.GetSpecialCurrencyRate;

namespace Infrastructure.UnitTests.Services
{
    public class CurrencyExchangeRateServiceTest
    {
        internal class FakeHttpMessageHandler : HttpMessageHandler
        {
            private Queue<HttpResponseMessage> _responseMessage = new();

            internal void SetResponse(HttpResponseMessage mes)
            {
                _responseMessage.Enqueue(mes);
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_responseMessage.Dequeue());
            }
        }

        [Fact]
        public async Task GetCertainCurrencyRate_ApiException_ReturnsStatusUnseccessful()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            fakeHandler.SetResponse(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("Server Error")
            });
            var client = new HttpClient(fakeHandler);
            client.BaseAddress = new Uri("https://v6.exchangerate-api.com/v6/");
            var service = new CurrencyExchangeRateService(client);

            var response = await service.GetCertainCurrencyRate(new GetSpecialCurrencyRateQuery("USD", "EUR"));

            Assert.True(Status.UNSECCESSFUL == response.Status);
        }

        [Fact]
        public async Task GetCertainCurrencyRate_Null_ReturnsStatusUnseccessful()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            fakeHandler.SetResponse(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("null", System.Text.Encoding.UTF8, "application/json")
            });
            var client = new HttpClient(fakeHandler);
            client.BaseAddress = new Uri("https://v6.exchangerate-api.com/v6/");
            var service = new CurrencyExchangeRateService(client);

            var response = await service.GetCertainCurrencyRate(new GetSpecialCurrencyRateQuery("USD", "EUR"));

            Assert.True(Status.UNSECCESSFUL == response.Status);
        }

        [Fact]
        public async Task GetCertainCurrencyRate_UnRelatedData_ReturnsStatusUnseccessful()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            fakeHandler.SetResponse(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("""
                    {
                        "fsadsa":"asdsa"
                    }
                    """, System.Text.Encoding.UTF8, "application/json")
            });
            var client = new HttpClient(fakeHandler);
            client.BaseAddress = new Uri("https://v6.exchangerate-api.com/v6/");
            var service = new CurrencyExchangeRateService(client);

            var response = await service.GetCertainCurrencyRate(new GetSpecialCurrencyRateQuery("USD", "EUR"));

            Assert.True(Status.UNSECCESSFUL == response.Status);
        }

        [Fact]
        public async Task GetCertainCurrencyRate_JsonException_ReturnsStatusUnseccessful()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            fakeHandler.SetResponse(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("""{ "invalid_json...""")
            });
            var client = new HttpClient(fakeHandler);
            client.BaseAddress = new Uri("https://v6.exchangerate-api.com/v6/");
            var service = new CurrencyExchangeRateService(client);

            var response = await service.GetCertainCurrencyRate(new GetSpecialCurrencyRateQuery("USD", "EUR"));

            Assert.True(Status.UNSECCESSFUL == response.Status);
        }
    }
}
