using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public int ActiveCategoryCountAsync()
		{
			return _categoryDal.ActiveCategoryCount();
		}
		public int PassiveCategoryCountAsync()
		{
			return _categoryDal.PassiveCategoryCount();
		}

		public void AddAsync(Category entity)
        {
            _categoryDal.Add(entity);  
        }

		public int CategoryCountAsync()
		{
			return _categoryDal.CategoryCount();//Dal katmanında var olan metot
		}

		public void DeleteAsync(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category GetByIdAsync(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetListAllAsync()
        {
            return _categoryDal.GetListAll();
        }

		public void UpdateAsync(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
