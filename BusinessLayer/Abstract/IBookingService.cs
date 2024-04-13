using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
		/// <summary>
		/// Rezervasyon Onaylandı
		/// </summary>
		/// <param name="id"></param>
		void BookingStatusApprovedAsync(int id);
		/// <summary>
		/// Rezervasyon İptal Edildi
		/// </summary>
		/// <param name="id"></param>
		void BookingStatusCanselledAsync(int id);
	}
}
