using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Application.Common.Interfaces;


namespace Application.Features.Currencies.Queries.PullAllCurrencyInfo
{
    public record PullAllCurrencyInfoQuery : IRequest<List<CurrencyInfoDto>>;

    public class PullAllCurrencyInfoQueryHandler : IRequestHandler<PullAllCurrencyInfoQuery, List<CurrencyInfoDto>>
    {
        private readonly ICurrencyInfoService _currencyInfoService;

        public PullAllCurrencyInfoQueryHandler(ICurrencyInfoService currencyInfoService)
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
