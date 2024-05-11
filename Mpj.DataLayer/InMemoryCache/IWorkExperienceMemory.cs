using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
    public interface IWorkExperienceMemory : IMemoryCache<List<WorkExperienceRecords>>
    {
    }

    public class WorkExperienceMemory : DistributedMemoryCache<List<WorkExperienceRecords>>, IWorkExperienceMemory
    {
        public WorkExperienceMemory(IDistributedCache cache) : base(cache)
        {
        }
    }
}
