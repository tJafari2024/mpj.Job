using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface IEducationalRecordMemoryCache : IMemoryCache<List<EducationalRecords>>
    {
    }

    public class EducationalRecordMemoryCache : DistributedMemoryCache<List<EducationalRecords>>, IEducationalRecordMemoryCache
    {
        public EducationalRecordMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
