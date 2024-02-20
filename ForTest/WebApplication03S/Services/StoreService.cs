using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using WebApplication03HW2.Abstraction;
using WebApplication03HW2.Models;
using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Services
{
    public class StoreService : IStoreService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public StoreService(DBContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddStore(StoreDto store)
        {
            using (_context)
            {
                var entity = _mapper.Map<Store>(store);

                _context.Stores.Add(entity);
                _context.SaveChanges();
                _cache.Remove("stores");

                return entity.Id;
            }
        }

        public IEnumerable<StoreDto> GetStores()
        {
            using (_context)
            {
                if (_cache.TryGetValue("stores", out List<StoreDto> stores))
                    return stores;

                stores = _context.Stores.Select(x => _mapper.Map<StoreDto>(x)).ToList();
                _cache.Set("stores", stores, TimeSpan.FromMinutes(30));

                return stores;
            }
        }
    }
}
