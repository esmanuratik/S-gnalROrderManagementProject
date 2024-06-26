﻿using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactDTO;
using DtoLayer.DiscountDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountsController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountsController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.GetListAllAsync());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.AddAsync(new Discount()
			{
				Amount = createDiscountDto.Amount,
				Description = createDiscountDto.Description,
				ImageUrl = createDiscountDto.ImageUrl,
				Title = createDiscountDto.Title,
				Status = false
			});
			return Ok("İndirim Bilgileri Başarıyla Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.GetByIdAsync(id);
			_discountService.DeleteAsync(value);

			return Ok("İndirim Bilgileri Başarıyla Silindi.");

		}
		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.GetByIdAsync(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.UpdateAsync(new Discount()
			{
				DiscountID = updateDiscountDto.DiscountID,
				Amount = updateDiscountDto.Amount,
				Description = updateDiscountDto.Description,
				ImageUrl = updateDiscountDto.ImageUrl,
				Title = updateDiscountDto.Title,
				Status = false
			});

			return Ok("İndirim Bilgileri Başarıyla Güncellendi");
		}
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.ChangeStatusToTrueAsync(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi");
		}
		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.ChangeStatusToFalseAsync(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi");
		}
		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue()
		{
			return Ok(_discountService.GetListByStatusTrueAsync());
		}
	}
}
