using AutoMapper;
using DtoLayer.ContactDTO;
using DtoLayer.DiscountDTO;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();//ReverseMap Discount UpdateDiscountDto ile UpdatDiscountDto Discount ile eşleşebilir anlamına geliyor.
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
        }
    }
}
