using AutoMapper;
using DtoLayer.MenuTableDTO;
using EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();   
        }
    }
}
