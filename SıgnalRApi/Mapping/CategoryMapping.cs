using AutoMapper;
using DtoLayer.BookingDTO;
using DtoLayer.CategoryDTO;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();//ReverseMap Category UpdateCategoryDto ile UpdateCategoryDto Category ile eşleşebilir anlamına geliyor.
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }
    }
}
