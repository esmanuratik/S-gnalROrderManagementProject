﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EFDiscountDal(SignalRContext context) : base(context)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.Status = true;
			context.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Where(x => x.Status == true).ToList();
			return value;	
		}
	}
}
