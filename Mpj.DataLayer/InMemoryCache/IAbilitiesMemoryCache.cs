using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;


namespace Mpj.DataLayer.InMemoryCache
{
    public interface IAbilitiesMemoryCache : IMemoryCache<AbilitiesDTOMem>
    {
    }

    public class AbilitiesMemoryCache : DistributedMemoryCache<AbilitiesDTOMem>, IAbilitiesMemoryCache
    {
        public AbilitiesMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
