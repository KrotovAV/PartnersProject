using AutoMapper;
using WebApplication03HW2.Models;
using WebApplication03HW2.Models.DTO;

namespace WebApplication03HW2.Repo
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<Store, StoreDto>(MemberList.Destination).ReverseMap();
        }
    }
}
