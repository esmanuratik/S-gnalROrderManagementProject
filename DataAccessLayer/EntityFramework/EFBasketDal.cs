using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EFBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x=>x.MenuTableID==id).Include(y=>y.Product).ToList();

            return values;
        }
    }
}
