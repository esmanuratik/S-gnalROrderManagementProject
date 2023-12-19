using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]  
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.AddAsync(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                CategoryStatus = true,
            }) ;
            return Ok("Kategori başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
           var value= _categoryService.GetByIdAsync(id) ;
            _categoryService.DeleteAsync(value);

            return Ok("Kategori başarıyla silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.UpdateAsync(new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryStatus = updateCategoryDto.CategoryStatus,
                CategoryID=updateCategoryDto.CategoryID,    
            });

            return Ok("Kategori başarıyla güncellendi");
        }
    }
}
