using Application.Features.Currencies.Queries.PullAllCurrencyInfo;

namespace Application.Common.Interfaces
{
    public interface ICurrencyFreaksService
    {
        public Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default);
    }
}
