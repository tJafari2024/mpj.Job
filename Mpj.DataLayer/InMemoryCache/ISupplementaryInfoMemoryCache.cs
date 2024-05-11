using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface ISupplementaryInfoMemoryCache : IMemoryCache<FurtherInformationDTO>
    {
    }

    public class SupplementaryInfoMemoryCache : DistributedMemoryCache<FurtherInformationDTO>, ISupplementaryInfoMemoryCache
    {
        public SupplementaryInfoMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
