using Application.Features.Currencies.Queries.PullAllCurrencyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrencyFreaksService
    {
        Task<List<CurrencyInfoDto>> GetAllCurreencyInfoAsync(CancellationToken cancellationToken = default);
    }
}
