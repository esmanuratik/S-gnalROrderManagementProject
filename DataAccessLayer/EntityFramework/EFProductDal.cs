using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x=>x.Category).ToList();//Product içine Category dahil et demektir böylece ürünler kategorileriyle birlikte gelmiş olacak.
            return values;
        }

		public int ProductCount()
		{
			using var context = new SignalRContext(); //using bloğunu kullanmak, kodunuzun daha güvenilir, temiz ve performanslı olmasına yardımcı olur. Bu yapı, kaynak yönetimi konusunda manuel işlemleri azaltarak yazılımınızın kalitesini artırır., IDisposable arabirimini uygulayan nesnelerin kullanımını daha güvenli ve temiz hale getirir. Bu yapı, belirli bir nesnenin kullanımı bittiği anda o nesnenin Dispose() metodunu çağırarak kaynakların serbest bırakılmasını sağlar. Bu da bellek sızıntılarını önler ve kaynak kullanımını daha etkin hale getirir.
			return context.Products.Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context= new SignalRContext();
			return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
		}
		//Fiyatların Ortalamasını alıyoruz
		public decimal ProductPriceAvg()
		{
			using var context=new SignalRContext();
			return context.Products.Average(x=>x.Price);
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x=>x.Price==(context.Products.Max(y=>y.Price))).Select(z=>z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}
		//Ortalama hamburger fiyatı
		public decimal ProductAvgPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
		}
	}
}
