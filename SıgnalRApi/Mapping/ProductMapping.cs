using AutoMapper;
using DtoLayer.FeatureDTO;
using DtoLayer.ProductDTO;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{

    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product,ResultProductWithCategoryDto>().ReverseMap();
        }
    }
}
