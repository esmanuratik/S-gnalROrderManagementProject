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
			_menuTableDal.Add(entity);
		}

		public void DeleteAsync(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
		}

		public MenuTable GetByIdAsync(int id)
		{
			return _menuTableDal.GetById(id);
		}

		public List<MenuTable> GetListAllAsync()
		{
			return _menuTableDal.GetListAll();
		}

		public int MenuTableCountAsync()
		{
			return _menuTableDal.MenuTableCount();
		}

		public void UpdateAsync(MenuTable entity)
		{
			_menuTableDal.Update(entity);
		}
	}
}
 