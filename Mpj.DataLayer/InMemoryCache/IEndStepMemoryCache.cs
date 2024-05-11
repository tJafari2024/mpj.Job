using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;


namespace Mpj.DataLayer.InMemoryCache
{
    public interface IEndStepMemoryCache : IMemoryCache<EndStepDTO>
    {
    }

    public class EndStepMemoryCache : DistributedMemoryCache<EndStepDTO>, IEndStepMemoryCache
    {
        public EndStepMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
