using AutoMapper;
using WebApplication03HW2.Models;
using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Store, StoreDto>().ReverseMap();
        }
    }
}
