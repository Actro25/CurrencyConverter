using MediatR;
using Application.Common.Interfaces;


namespace Application.Features.Currencies.Queries.PullAllCurrencyInfo
{
    public record PullAllCurrencyInfoQuery : IRequest<List<CurrencyInfoDto>>;

    public class PullAllCurrencyInfoQueryHandler : IRequestHandler<PullAllCurrencyInfoQuery, List<CurrencyInfoDto>>
    {
        private readonly ICurrencyFreaksService _currencyInfoService;

        public PullAllCurrencyInfoQueryHandler(ICurrencyFreaksService currencyInfoService)
        {
            _currencyInfoService = currencyInfoService;
        }

        public async Task<List<CurrencyInfoDto>> Handle(PullAllCurrencyInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await _currencyInfoService.GetAllCurreencyInfoAsync();

            return data;
        }
    }
}
