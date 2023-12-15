using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x=>x.Category).ToList();//Product içine Category dahil et demektir böylece ürünler kategorileriyle birlikte gelmiş olacak.
            return values;
        }
    }
}
