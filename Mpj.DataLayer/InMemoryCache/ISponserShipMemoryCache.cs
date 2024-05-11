
using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface ISponserShipMemoryCache : IMemoryCache<List<SpouseDTO>>
    {
    }

    public class SponserShipMemoryCache : DistributedMemoryCache<List<SpouseDTO>>, ISponserShipMemoryCache
    {
        public SponserShipMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
