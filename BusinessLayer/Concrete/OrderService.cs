using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class OrderService : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderService(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int ActiveOrderCountAsync()
		{
			return _orderDal.ActiveOrderCount();
		}

		public void AddAsync(Order entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteAsync(Order entity)
		{
			throw new NotImplementedException();
		}

		public Order GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public List<Order> GetListAllAsync()
		{
			throw new NotImplementedException();
		}

		public decimal LastOrderPriceAsync()
		{
			return _orderDal.LastOrderPrice();
		}

		public int TotalOrderCountAsync()
		{
			return _orderDal.TotalOrderCount();
		}

		public void UpdateAsync(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
