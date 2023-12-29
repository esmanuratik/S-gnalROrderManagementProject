﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			return Ok(_orderService.TotalOrderCountAsync());
		}
		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount()
		{
			return Ok(_orderService.ActiveOrderCountAsync());
		}
		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice()
		{
			return Ok(_orderService.LastOrderPriceAsync());
		}
	}
}
