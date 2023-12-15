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
    public class AboutService : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AddAsync(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void DeleteAsync(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About GetByIdAsync(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> GetListAllAsync()
        {
            return _aboutDal.GetListAll();
        }

        public void UpdateAsync(About entity)
        {
            _aboutDal.Update(entity);   
        }
    }
}
