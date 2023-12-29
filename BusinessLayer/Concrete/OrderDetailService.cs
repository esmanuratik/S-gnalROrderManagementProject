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
	public class OrderDetailService : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

		public OrderDetailService(IOrderDetailDal orderDetailDal)
		{
			_orderDetailDal = orderDetailDal;
		}

		public void AddAsync(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteAsync(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public OrderDetail GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public List<OrderDetail> GetListAllAsync()
		{
			throw new NotImplementedException();
		}

		public void UpdateAsync(OrderDetail entity)
		{
			throw new NotImplementedException();
		}
	}
}
