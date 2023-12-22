using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DiscountDTO;
using DtoLayer.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SıgnalRApi.DAL.Entities;
using System.Collections.Generic;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.GetListAllAsync());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            //var value = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.GetProductsWithCategoriesAsync());
            //return Ok(value);
            var context=new SignalRContext();
            var values=context.Products.Include(x => x.Category).Select(y=>new ResultProductWithCategoryDto
            {
                CategoryName=y.Category.CategoryName,
                Description=y.Description,
                ImageUrl=y.ImageUrl,
                Price=y.Price,
                ProductID=y.ProductID,
                ProductName=y.ProductName,
                ProductStatus = y.ProductStatus 
            });
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.AddAsync(new Product()
            {
                ProductStatus = createProductDto.ProductStatus,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                CategoryID=createProductDto.CategoryID,
            });
            return Ok("Ürün Bilgileri Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetByIdAsync(id);
            _productService.DeleteAsync(value);

            return Ok("Ürün Bilgileri Başarıyla Silindi.");

        }
        
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.UpdateAsync(new Product()
            {
                ProductStatus = updateProductDto.ProductStatus,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductID= updateProductDto.ProductID,
                CategoryID= updateProductDto.CategoryID,
            });

            return Ok("İndirim Bilgileri Başarıyla Güncellendi");
        }
    }
}
