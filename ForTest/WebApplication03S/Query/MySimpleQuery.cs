using WebApplication03HW2.Abstraction;
using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Query
{
    public class MySimpleQuery
    {
        //public IEnumerable<ProductDto> GetProducts([Service] IProductService service) => service.GetProducts();
        public IEnumerable<StoreDto> GetStorages([Service] IStoreService service) => service.GetStores();
       // public IEnumerable<GroupDto> GetCategories([Service] IGroupService service) => service.GetCategories();
    }
}
