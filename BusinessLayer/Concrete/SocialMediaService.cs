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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaService(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void AddAsync(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);    
        }

        public void DeleteAsync(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public SocialMedia GetByIdAsync(int id)
        {
           return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> GetListAllAsync()
        {
            return _socialMediaDal.GetListAll();
        }

        public void UpdateAsync(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
