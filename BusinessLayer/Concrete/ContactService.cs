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
    public class ContactService : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddAsync(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void DeleteAsync(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact GetByIdAsync(int id)
        {
           return _contactDal.GetById(id);
        }

        public List<Contact> GetListAllAsync()
        {
            return _contactDal.GetListAll();
        }

        public void UpdateAsync(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
