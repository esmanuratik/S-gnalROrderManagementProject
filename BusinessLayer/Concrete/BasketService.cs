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
    public class BasketService : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketService(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void AddAsync(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void DeleteAsync(Basket entity)
        {
           _basketDal.Delete(entity);
        }

        public List<Basket> GetBasketByMenuTableNumberAsync(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }

        public Basket GetByIdAsync(int id)
        {
           return _basketDal.GetById(id);
        }

        public List<Basket> GetListAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
