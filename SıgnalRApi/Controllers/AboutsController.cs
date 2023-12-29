using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DtoLayer.AboutDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _mapper.Map<List<ResultAboutDto>>(_aboutService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.AddAsync(new About()
            {
               Description=createAboutDto.Description,
               ImageUrl=createAboutDto.ImageUrl,
               Title=createAboutDto.Title,
            });
            return Ok("Hakkımda bölümü başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.GetByIdAsync(id);
            _aboutService.DeleteAsync(value);

            return Ok("Hakkımda bölümü başarıyla silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateCategoryDto)
        {
            _aboutService.UpdateAsync(new About()
            {
              AboutID = updateCategoryDto.AboutID,
              Title = updateCategoryDto.Title,
              ImageUrl = updateCategoryDto.ImageUrl,
              Description=updateCategoryDto.Description,
            });

            return Ok("Hakkımda başarıyla güncellendi");
        }

    }
}
