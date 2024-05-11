using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.InMemoryCache;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{

    public interface IAuthenticationMemoryCache : IMemoryCache<AuthenticationDTO>
    {
    }

    public class AuthenticationMemoryCache : DistributedMemoryCache<AuthenticationDTO>, IAuthenticationMemoryCache
    {
        public AuthenticationMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
