
using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface IPersonalImageMemoryCache : IMemoryCache<PersonalImageNameMem>
    {
    }

    public class PersonalImageMemoryCache : DistributedMemoryCache<PersonalImageNameMem>, IPersonalImageMemoryCache
    {
        public PersonalImageMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
