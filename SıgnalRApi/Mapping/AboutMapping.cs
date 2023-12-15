using AutoMapper;
using DtoLayer.AboutDTO;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class AboutMapping:Profile 
    {
        public AboutMapping()
        {
            CreateMap<About,UpdateAboutDto>().ReverseMap();//ReverseMap About UpdateAboutDto ile UpdateAboutDto About ile eşleşebilir anlamına geliyor.
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();    
        }
    }
}
