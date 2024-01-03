using DataAccessLayer.Abstract;
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
	public class EFMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		public EFMenuTableDal(SignalRContext context) : base(context)
		{
		}

		public int MenuTableCount()
		{
			using var context=new SignalRContext();
			return context.MenuTables.Count();
		}
	}
}
