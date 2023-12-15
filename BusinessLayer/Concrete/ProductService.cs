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

        public void UpdateAsync(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
