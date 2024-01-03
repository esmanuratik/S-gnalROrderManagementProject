using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MoneyCaseService : IMoneyCaseService
	{
		IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseService(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void AddAsync(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteAsync(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public MoneyCase GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> GetListAllAsync()
		{
			throw new NotImplementedException();
		}

		public decimal TotalMoneyCaseAmountAsync()
		{
			return _moneyCaseDal.TotalMoneyCaseAmount();
		}

		public void UpdateAsync(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
