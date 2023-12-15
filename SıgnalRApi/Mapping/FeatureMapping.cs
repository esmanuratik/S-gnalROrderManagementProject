using AutoMapper;
using DtoLayer.DiscountDTO;
using DtoLayer.FeatureDTO;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
        }
    }
}
