using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
  
    public interface ILowMemoryCache : IMemoryCache<LowDTO>
    {
    }

    public class LowMemoryCache : DistributedMemoryCache<LowDTO>, ILowMemoryCache
    {
        public LowMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
