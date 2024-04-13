using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using SıgnalRApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingService(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void AddAsync(Booking entity)
        {
            _bookingDal.Add(entity);
        }

		public void BookingStatusApprovedAsync(int id)
		{
			_bookingDal.BookingStatusApproved(id);
		}

		public void BookingStatusCanselledAsync(int id)
		{
			_bookingDal.BookingStatusCanselled(id);
		}

		public void DeleteAsync(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking GetByIdAsync(int id)
        {
           return  _bookingDal.GetById(id);
        }

        public List<Booking> GetListAllAsync()
        {
            return _bookingDal.GetListAll();
        }

        public void UpdateAsync(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
