using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Memory;

namespace Mpj.DataLayer.InMemoryCache{
    public interface IMemoryCache<T> where T : class
    {
        T? Get(string key);

        void Set(string key, T value);  
    }

    public class DistributedMemoryCache<T> : IMemoryCache<T> where T : class
    {
        private readonly IDistributedCache _cache; 

        public DistributedMemoryCache(IDistributedCache cache)
        {
            _cache = cache;
        }
         

        public T? Get(string key)
        {
            var dataModel = _cache.GetString(key);
            return dataModel is not null
                ? JsonConvert.DeserializeObject<T>(dataModel)
                : null;
        }

        public void Set(string key, T value)
        {
            var serializedData = JsonConvert.SerializeObject(value);
            // var expirationOptions = new MemoryCacheEntryOptions
            //{
            //   SlidingExpiration = TimeSpan.FromMinutes(20),
            //   Priority = CacheItemPriority.Normal,
            // AbsoluteExpiration = DateTime.Now.AddMinutes(50)
            // };
            var options = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(20),
                AbsoluteExpiration = DateTime.Now.AddMinutes(50),


            };
                //.SetSlidingExpiration(TimeSpan.FromMinutes(30)
                
            //);
            _cache.SetString(key,serializedData,options);
            //_cache.SetString(key, serializedData);
        }
    } 

}
