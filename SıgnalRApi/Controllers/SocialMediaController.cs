using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDTO;
using DtoLayer.SocialMediaDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.AddAsync(new SocialMedia()
            {
                Icon= createSocialMediaDto.Icon,
                Title= createSocialMediaDto.Title,
                Url= createSocialMediaDto.Url,
            });
            return Ok("Sosyal Medya Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.GetByIdAsync(id);
            _socialMediaService.DeleteAsync(value);

            return Ok("Sosyal Medya Başarıyla Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.UpdateAsync(new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title= updateSocialMediaDto.Title,
                Url= updateSocialMediaDto.Url,
                SocialMediaID= updateSocialMediaDto.SocialMediaID,
            });

            return Ok("Sosyal MEdya Başarıyla Güncellendi");
        }
    }
}
