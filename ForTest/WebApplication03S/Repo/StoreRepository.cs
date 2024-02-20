using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebApplication03HW2.Abstraction;
using WebApplication03HW2.Models.DTO;
using WebApplication03HW2.Models;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Reflection;

namespace WebApplication03HW2.Repo
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public StoreRepository(IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _cache = cache;
        }

        public IEnumerable<StoreDto> GetStores()
        {
            if (_cache.TryGetValue("stores", out List<StoreDto>? stores))
            {
                return stores;
            }

            using (var context = new DBContext())
            {
                var storesList = context.Stores.Select(x => _mapper.Map<StoreDto>(x)).ToList();
                _cache.Set("stores", storesList, TimeSpan.FromMinutes(30));
                return storesList;
            }
        }

        public int AddStore(StoreDto store)
        {
            using (var context = new DBContext())
            {
                var entityStore = context.Stores.FirstOrDefault(x => x.Name.ToLower() == store.Name.ToLower());
                if (entityStore == null)
                {
                    
                    entityStore = _mapper.Map<Models.Store>(store);
                    context.Stores.Add(entityStore);
                    context.SaveChanges();
                    _cache.Remove("stores");
                }
                return entityStore.Id;
            }
        }
        public bool DeleteStore(int id)
        {
            using (var context = new DBContext())
            {
                Store entityStore = context.Stores.FirstOrDefault(x => x.Id == id)!;
                if (entityStore == null)
                    return false;

                context.Stores.Remove(entityStore);
                context.SaveChanges();
                _cache.Remove("stores");
                return true;
            }
        }

        public bool CheckStore(int id)
        {
            using (var context = new DBContext())
            {
                Store entityStore = context.Stores.FirstOrDefault(x => x.Id == id)!;
                if (entityStore == null)
                    return false;

                return true;
            }
        }
        //3-------------------
        //public string GetProductsCSV()
        //{
        //    var sb = new StringBuilder();
        //    var products = GetProducts();

        //    foreach (var product in products)
        //    {
        //        sb.AppendLine($"{product.Id},{product.Name}, {product.Description}");
        //    }

        //    return sb.ToString();
        //}



        //public string GetСacheStatCSV()
        //{
        //    var curCache = _cache.GetCurrentStatistics();
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"CurrentEntryCount, {curCache.CurrentEntryCount.ToString()}")
        //      .AppendLine($"CurrentEstimatedSize, {curCache.CurrentEstimatedSize.ToString()}")
        //      .AppendLine($"TotalHits, {curCache.TotalHits.ToString()}")
        //      .AppendLine($"TotalMisses, {curCache.TotalMisses.ToString()}");
        //    return sb.ToString();
        //}

    }
}
