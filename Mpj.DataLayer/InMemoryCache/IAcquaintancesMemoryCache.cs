using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface IAcquaintancesMemoryCache : IMemoryCache<AcquaintancesDTO>
    {
    }

    public class AcquaintancesMemoryCache : DistributedMemoryCache<AcquaintancesDTO>, IAcquaintancesMemoryCache
    {
        public AcquaintancesMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
