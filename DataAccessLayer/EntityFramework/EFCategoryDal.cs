using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int CategoryCount() //Bu metodu business tarafında da çağırman gerekiyor.
		{
			using var context = new SignalRContext(); //using bloğunu kullanmak, kodunuzun daha güvenilir, temiz ve performanslı olmasına yardımcı olur. Bu yapı, kaynak yönetimi konusunda manuel işlemleri azaltarak yazılımınızın kalitesini artırır., IDisposable arabirimini uygulayan nesnelerin kullanımını daha güvenli ve temiz hale getirir. Bu yapı, belirli bir nesnenin kullanımı bittiği anda o nesnenin Dispose() metodunu çağırarak kaynakların serbest bırakılmasını sağlar. Bu da bellek sızıntılarını önler ve kaynak kullanımını daha etkin hale getirir.
			return context.Categories.Count();
		}
		public int ActiveCategoryCount()
		{
			using var context= new SignalRContext();
			return context.Categories.Where(x=>x.CategoryStatus==true).Count();
		}

		public int PassiveCategoryCount()
		{
			using var context=new SignalRContext();
			return context.Categories.Where(x=>x.CategoryStatus==false).Count();
		}
	}
}
