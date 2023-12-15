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
    public class EFFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EFFeatureDal(SignalRContext context) : base(context)
        {
        }
    }
}
