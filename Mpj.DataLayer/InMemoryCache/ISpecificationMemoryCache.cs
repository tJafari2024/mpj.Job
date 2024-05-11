using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface ISpecificationMemoryCache : IMemoryCache<SpecificationsDTO>
    {
    }

    public class SpecificationMemoryCache : DistributedMemoryCache<SpecificationsDTO>, ISpecificationMemoryCache
    {
        public SpecificationMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
