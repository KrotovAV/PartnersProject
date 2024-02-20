using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Abstraction
{
    public interface IStoreRepository
    {
        //public IEnumerable<GroupDto> GetGroups();
        //public int AddGroup(GroupDto group);
        //public bool DeleteGroup(int id);


        //public IEnumerable<ProductDto> GetProducts();
        //public int AddProduct(ProductDto product);
        //public bool DeleteProduct(int id);

        public IEnumerable<StoreDto> GetStores();
        public int AddStore(StoreDto store);
        public bool DeleteStore(int id);
        public bool CheckStore(int id);

        //public string GetProductsCSV();
        //public string GetСacheStatCSV();


    }
    
}
