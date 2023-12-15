using AutoMapper;
using DtoLayer.ProductDTO;
using DtoLayer.SocialMediaDTO;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
        }
    }
}
