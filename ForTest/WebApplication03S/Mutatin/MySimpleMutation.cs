using WebApplication03HW2.Abstraction;
using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Mutatin
{
    public class MySimpleMutation
    {

        public int AddStore(StoreDto store, [Service] IStoreService service)
        {
            var id = service.AddStore(store);
            return id;
        }
    }
}
