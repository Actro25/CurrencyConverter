using MediatR;
using Application.Common.Interfaces;


namespace Application.Features.Currencies.Queries.PullAllCurrencyInfo
{
    public record PullAllCurrencyInfoQuery(ProviderType Provider) : IRequest<List<CurrencyInfoDto>>;

    public class PullAllCurrencyInfoQueryHandler : IRequestHandler<PullAllCurrencyInfoQuery, List<CurrencyInfoDto>>
    {
        private readonly IEnumerable<ICurrencyProvider> _providers;

        public PullAllCurrencyInfoQueryHandler(IEnumerable<ICurrencyProvider> providers)
        {
            _providers = providers;
        }
        public async Task<List<CurrencyInfoDto>> Handle(PullAllCurrencyInfoQuery request, CancellationToken cancellationToken)
        {
            var provider = _providers.FirstOrDefault(p => p.ProviderType == request.Provider)
                ?? throw new Exception($"Провайдер {request.Provider} не знайдений");
            return await provider.GetAllCurreencyInfoAsync();
        }
    }
}
