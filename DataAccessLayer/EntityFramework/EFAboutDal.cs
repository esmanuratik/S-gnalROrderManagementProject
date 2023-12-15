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
    //IAboutDal dan miras almasının sebebi ileride About a özgü metotlar gelebilir bu durumda IAboutDal devreye girmiş olacak.
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(SignalRContext context) : base(context)
        {
        }
    }
}
