﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EFMoneyCaseDal(SignalRContext context) : base(context)
		{
		}

		public decimal TotalMoneyCaseAmount()
		{
			using var context=new SignalRContext();
			return context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
		}
	}
}
