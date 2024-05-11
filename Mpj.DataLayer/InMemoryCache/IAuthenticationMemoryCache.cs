using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.InMemoryCache;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{

    public interface IAuthorizationMemoryCache : IMemoryCache<AuthorizationDTO>
    {
    }

    public class AuthorizationMemoryCache : DistributedMemoryCache<AuthorizationDTO>, IAuthorizationMemoryCache
    {
        public AuthorizationMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
