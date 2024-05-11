using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;

namespace Mpj.DataLayer.InMemoryCache
{
  
    public interface IEditItemForEmploymentMemoryCache : IMemoryCache<EditItemForEmploymentDTO>
    {
    }

    public class EditItemForEmploymentMemoryCache : DistributedMemoryCache<EditItemForEmploymentDTO>, IEditItemForEmploymentMemoryCache
    {
        public EditItemForEmploymentMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
