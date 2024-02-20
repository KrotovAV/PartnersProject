using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Abstraction
{
    public interface IStoreService
    {
        IEnumerable<StoreDto> GetStores();
        int AddStore(StoreDto storage);

        
    }
}
