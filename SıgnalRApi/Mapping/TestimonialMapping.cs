using AutoMapper;
using DtoLayer.SocialMediaDTO;
using DtoLayer.TestimonialDTO;
using EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
        }
    }
}
