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
	public class MenuTableService : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;

		public MenuTableService(IMenuTableDal menuTableDal)
		{
			_menuTableDal = menuTableDal;
		}

		public void AddAsync(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteAsync(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public MenuTable GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public List<MenuTable> GetListAllAsync()
		{
			throw new NotImplementedException();
		}

		public int MenuTableCountAsync()
		{
			return _menuTableDal.MenuTableCount();
		}

		public void UpdateAsync(MenuTable entity)
		{
			throw new NotImplementedException();
		}
	}
}
 