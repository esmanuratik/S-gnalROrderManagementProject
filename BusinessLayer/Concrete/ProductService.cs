using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

		public ProductService(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void AddAsync(Product entity)
        {
           _productDal.Add(entity);
        }

        public void DeleteAsync(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product GetByIdAsync(int id)
        {
           return _productDal.GetById(id);  
        }

        public List<Product> GetListAllAsync()
        {
            return _productDal.GetListAll();
        }

        public List<Product> GetProductsWithCategoriesAsync()
        {
            return _productDal.GetProductsWithCategories();
        }

		public int ProductCountAsync()
		{
			return _productDal.ProductCount();
		}

		public int ProductCountByCategoryNameDrinkAsync()
		{
  			return _productDal.ProductCountByCategoryNameDrink();
		}

		public int ProductCountByCategoryNameHamburgerAsync()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public string ProductNameByMaxPriceAsync()
		{
			return _productDal.ProductNameByMaxPrice();
		}

		public string ProductNameByMinPriceAsync()
		{
			return _productDal.ProductNameByMinPrice();
		}

		//Fiyatların Ortalamasını alıyoruz
		public decimal ProductPriceAvgAsync()
		{
			return _productDal.ProductPriceAvg();
		}
		//Hamburger Fiyatlarının Ortalamasını Alıyoruz
		public decimal ProductAvgPriceByHamburgerAsync()
		{
			return _productDal.ProductAvgPriceByHamburger();
		}

		public void UpdateAsync(Product entity)
        {
            _productDal.Update(entity);
        }

        public decimal ProductPriceBySteakBurgerAsync()
        {
           return  _productDal.ProductPriceBySteakBurger();
        }

        public decimal TotalPriceByDrinkCategoryAsync()
        {
            return _productDal.TotalPriceByDrinkCategory();
        }

        public decimal TotalPriceBySaladCategoryAsync()
        {
            return _productDal.TotalPriceBySaladCategory();
        }
    }
}
