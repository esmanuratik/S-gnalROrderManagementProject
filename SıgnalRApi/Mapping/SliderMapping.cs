using AutoMapper;
using DtoLayer.SliderDTO;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();//ReverseMap About UpdateAboutDto ile UpdateAboutDto About ile eşleşebilir anlamına geliyor.
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, ResultSliderDto>().ReverseMap();         
        }
    }
}
