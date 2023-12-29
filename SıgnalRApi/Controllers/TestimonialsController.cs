using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDTO;
using DtoLayer.TestimonialDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

		public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}
      

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.AddAsync(new Testimonial()
            {
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
            });
            return Ok("Referanslar Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.GetByIdAsync(id);
            _testimonialService.DeleteAsync(value);

            return Ok("Referanslar Başarıyla Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.UpdateAsync(new Testimonial()
            {
                Comment = updateTestimonialDto.Comment,
                Name = updateTestimonialDto.Name,
                Status = updateTestimonialDto.Status,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Title = updateTestimonialDto.Title,
                TestimonialID = updateTestimonialDto.TestimonialID
            });

            return Ok("Referanslar Başarıyla Güncellendi");
        }
    }
}
