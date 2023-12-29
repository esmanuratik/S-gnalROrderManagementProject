using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDTO;
using DtoLayer.FeatureDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(_featureService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.AddAsync(new Feature()
            {
                Description1=createFeatureDto.Description1,
                Description2=createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
                
            });
            return Ok("Öne Çıkanlar Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.GetByIdAsync(id);
            _featureService.DeleteAsync(value);

            return Ok("Öne Çıkanlar Başarıyla Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.UpdateAsync(new Feature()
            {
               Description1 = updateFeatureDto.Description1,
               Description2 = updateFeatureDto.Description2,
               Description3 = updateFeatureDto.Description3,
               Title1 = updateFeatureDto.Title1,
               Title2 = updateFeatureDto.Title2,
               Title3 = updateFeatureDto.Title3,
               FeatureID = updateFeatureDto.FeatureID   
               
            });

            return Ok("Öne Çıkanlar Güncellendi");
        }
    }
}
