﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EFOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x=>x.Description== "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context= new SignalRContext();
			return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count();
		}
	}
}
