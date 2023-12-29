using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService: IGenericService<Product>
    {
        List<Product> GetProductsWithCategoriesAsync();
        int ProductCountAsync();
		int ProductCountByCategoryNameHamburgerAsync();
		int ProductCountByCategoryNameDrinkAsync();
        decimal ProductPriceAvgAsync();//Fiyatların Ortalamasını alıyoruz
		string ProductNameByMaxPriceAsync();
		string ProductNameByMinPriceAsync();
		decimal ProductAvgPriceByHamburgerAsync();
	}
}
