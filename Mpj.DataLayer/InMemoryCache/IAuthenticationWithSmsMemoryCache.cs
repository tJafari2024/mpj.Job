using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.InMemoryCache;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{

    public interface IAuthenticationWithSmsMemoryCache : IMemoryCache<AuthenticationDTOWithSms>
    {
    }

    public class AuthenticationWithSmsMemoryCache : DistributedMemoryCache<AuthenticationDTOWithSms>, IAuthenticationWithSmsMemoryCache
    {
        public AuthenticationWithSmsMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
