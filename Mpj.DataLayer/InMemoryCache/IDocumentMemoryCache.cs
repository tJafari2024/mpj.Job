using Microsoft.Extensions.Caching.Distributed;
using Mpj.DataLayer.DTOs.EmploymentForm;


namespace Mpj.DataLayer.InMemoryCache
{
    public interface IDocumentMemoryCache : IMemoryCache<List<DocumentFileDTO>>
    {
    }

    public class DocumentMemoryCache : DistributedMemoryCache<List<DocumentFileDTO>>, IDocumentMemoryCache
    {
        public DocumentMemoryCache(IDistributedCache cache) : base(cache)
        {
        }
    }
}
