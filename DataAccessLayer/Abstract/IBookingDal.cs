using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        /// <summary>
        /// Rezervasyon Onaylandı
        /// </summary>
        /// <param name="id"></param>
        void BookingStatusApproved (int id);
        /// <summary>
        /// Rezervasyon İptal Edildi
        /// </summary>
        /// <param name="id"></param>
        void BookingStatusCanselled (int id);
    }
}
