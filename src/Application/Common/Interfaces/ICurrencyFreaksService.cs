using Application.Features.Currencies.Queries.PullAllCurrencyInfo;

namespace Application.Common.Interfaces
{
    public interface ICurrencyFreaksService
    {
        Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default);
    }
}
