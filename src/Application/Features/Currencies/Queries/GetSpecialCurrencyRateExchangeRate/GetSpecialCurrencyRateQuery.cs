using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Currencies.Queries.GetSpecialCurrencyRate
{
    public record GetSpecialCurrencyRateQuery(string BaseCode, string TargetCode, ProviderType Provider) : IRequest<CurrencyRateDto>;

    public class GetSpecialCurrencyRateQueryHandler : IRequestHandler<GetSpecialCurrencyRateQuery, CurrencyRateDto>
    {
        private readonly IEnumerable<ICurrencyProvider> _providers;

        public GetSpecialCurrencyRateQueryHandler(IEnumerable<ICurrencyProvider> providers)
        {
            _providers = providers;
        }
        public async Task<CurrencyRateDto> Handle(GetSpecialCurrencyRateQuery request, CancellationToken cancellationToken)
        {
            var provider = _providers.FirstOrDefault(p => p.ProviderType == request.Provider)
                ?? throw new Exception($"Провайдер {request.Provider} не знайдений");
            return await provider.GetCertainCurrencyRate(request);
        }
    }
}
