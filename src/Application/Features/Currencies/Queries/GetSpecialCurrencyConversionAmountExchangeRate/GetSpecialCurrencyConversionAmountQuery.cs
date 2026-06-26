using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Currencies.Queries.GetSpecialCurrencyConversionAmount
{
    public record GetSpecialCurrencyConversionAmountQuery(string BaseCode, string TargetCode, decimal Amount, ProviderType Provider) : IRequest<CurrencyConversionDto>;

    public class GetSpecialCurrencyConversionAmountQueryHandler : IRequestHandler<GetSpecialCurrencyConversionAmountQuery, CurrencyConversionDto>
    {
        private readonly IEnumerable<ICurrencyProvider> _providers;

        public GetSpecialCurrencyConversionAmountQueryHandler(IEnumerable<ICurrencyProvider> providers)
        {
            _providers = providers;
        }
        public async Task<CurrencyConversionDto> Handle(GetSpecialCurrencyConversionAmountQuery request, CancellationToken cancellationToken)
        {
            var provider = _providers.FirstOrDefault(p => p.ProviderType == request.Provider)
                ?? throw new Exception($"Провайдер {request.Provider} не знайдений");
            return await provider.GetCertainCurrencyConversionAmount(request);
        }
    }
}
