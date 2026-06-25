using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Currencies.Queries.GetSpecialCurrencyRate
{
    public record GetSpecialCurrencyRateQuery(string base_code, string target_code) : IRequest<CurrencyRateDto>;

    public class GetSpecialCurrencyRateQueryHandler : IRequestHandler<GetSpecialCurrencyRateQuery, CurrencyRateDto>
    {
        private readonly ICurrencyExchangeRateService _service;

        public GetSpecialCurrencyRateQueryHandler(ICurrencyExchangeRateService service)
        {
            _service = service;
        }

        public async Task<CurrencyRateDto> Handle(GetSpecialCurrencyRateQuery request, CancellationToken cancellationToken)
        {
            var data = await _service.GetCertainCurrencyRate(request);

            return data;
        }
    }
}
