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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.GetListAllAsync(); //TGetListAllAsync()
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,   
                Description = createAboutDto.Description,   
                ImageUrl = createAboutDto.ImageUrl,
            };

            _aboutService.AddAsync(about);//TAdd
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value=_aboutService.GetByIdAsync(id);//TGetById
            _aboutService.DeleteAsync(value);
            return Ok("Hakkımda alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                ImageUrl = updateAboutDto.ImageUrl, 
                Title = updateAboutDto.Title,   
                Description = updateAboutDto.Description,   
            };
           _aboutService.UpdateAsync(about);
           return Ok("Hakkımda alanı güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id) 
        {
            var value=_aboutService.GetByIdAsync(id);
            return Ok(value);   
        }

    }
}
