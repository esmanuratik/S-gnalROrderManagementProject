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
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountService(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void AddAsync(Discount entity)
        {
            _discountDal.Add(entity);
        }

		public void ChangeStatusToFalseAsync(int id)
		{
			_discountDal.ChangeStatusToFalse(id);
		}

		public void ChangeStatusToTrueAsync(int id)
		{
			_discountDal.ChangeStatusToTrue(id);
		}

		public void DeleteAsync(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount GetByIdAsync(int id)
        {
           return _discountDal.GetById(id);
        }

        public List<Discount> GetListAllAsync()
        {
            return _discountDal.GetListAll();
        }

		public List<Discount> GetListByStatusTrueAsync()
		{
			return _discountDal.GetListByStatusTrue();    
		}

		public void UpdateAsync(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
