using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDTO;
using DtoLayer.FeatureDTO;
using DtoLayer.SliderDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.AddAsync(new Slider()
            {
                Description1= createSliderDto.Description1,
                Description2= createSliderDto.Description2,
                Description3 = createSliderDto.Description3,
                Title1 = createSliderDto.Title1,
                Title2 = createSliderDto.Title2,
                Title3 = createSliderDto.Title3,
                
            });
            return Ok("Öne Çıkanlar Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.GetByIdAsync(id);
            _sliderService.DeleteAsync(value);

            return Ok("Öne Çıkanlar Başarıyla Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.UpdateAsync(new Slider()
            {
               Description1 = updateSliderDto.Description1,
               Description2 = updateSliderDto.Description2,
               Description3 = updateSliderDto.Description3,
               Title1 = updateSliderDto.Title1,
               Title2 = updateSliderDto.Title2,
               Title3 = updateSliderDto.Title3,
               SliderID = updateSliderDto.SliderID
            });

            return Ok("Öne Çıkanlar Güncellendi");
        }
    }
}
