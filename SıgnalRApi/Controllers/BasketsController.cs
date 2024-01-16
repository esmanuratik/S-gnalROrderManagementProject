using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DtoLayer.BasketDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SıgnalRApi.DAL.Entities;
using SıgnalRApi.Models;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values=_basketService.GetBasketByMenuTableNumberAsync(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableID==id).Select(z=> new ResultBasketListWithProduct
            {
                BasketID=z.BasketID,
                Count=z.Count,
                MenuTableID=z.MenuTableID,
                Price=z.Price,
                ProductID = z.ProductID,
                ProductName = z.Product.ProductName,
                TotalPrice = z.TotalPrice
               
            }).ToList(); 
            return Ok(values);
        }

        //Ürüne tıkladığım zaman o ürüne ait diğer özellikleri bulmalı burada bu işlemi yapıyorum
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context= new SignalRContext();
            _basketService.AddAsync(new Basket()
            {
                ProductID=createBasketDto.ProductID,
                Count=1,
                MenuTableID=4,
                Price=context.Products.Where(x=>x.ProductID==createBasketDto.ProductID).Select(y=>y.Price).FirstOrDefault(),
                TotalPrice=0
            });
            return Ok();
        }

        //Ürün Silme İşlemi
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.GetByIdAsync(id);
            _basketService.DeleteAsync(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
