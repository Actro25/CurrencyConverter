using Application.Features.Currencies;
using Infrastructure.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.UnitTests.Services
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
    public class CurrencyInfoServiceTest
    {
        [Fact]
        public async Task GetAllCurreencyInfoAsync_Null_ReturnsNewListCurrencyInfoDto()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            fakeHandler.SetResponse(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("null", System.Text.Encoding.UTF8, "application/json")
            });
            var client = new HttpClient(fakeHandler);
            client.BaseAddress = client.BaseAddress = new Uri("https://api.currencyfreaks.com/");
            var service = new CurrencyInfoService(client);

            var response = await service.GetAllCurreencyInfoAsync();

            Assert.Equivalent(new List<CurrencyInfoDto>(), response);
        }

        [Fact]
        public async Task GetAllCurreencyInfoAsync_ThrowsException_ReturnsNewListCurrencyInfoDtoAsync()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            fakeHandler.SetResponse(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("Server Error")
            });
            var client = new HttpClient(fakeHandler);
            client.BaseAddress = client.BaseAddress = new Uri("https://api.currencyfreaks.com/");
            var service = new CurrencyInfoService(client);

            var response = await service.GetAllCurreencyInfoAsync();

            Assert.Equivalent(new List<CurrencyInfoDto>(), response);
        }

    }
}
