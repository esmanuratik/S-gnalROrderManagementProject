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
    public class EFBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EFBookingDal(SignalRContext context) : base(context)
        {
        }
    }
}
