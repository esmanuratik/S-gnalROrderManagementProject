using BusinessLayer.Abstract;
using DtoLayer.BookingDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //rezervasyonlara durum ataması yapılacak: rezervasyon alındı , rezervasyon iptal edildi , rezervasyon geçmiş vs

        [HttpGet]
        public IActionResult BookingList()
        {
            var values=_bookingService.GetListAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking() 
            { 
                Email = createBookingDto.Email, 
                Name = createBookingDto.Name,
                PhoneNumber = createBookingDto.PhoneNumber,
                Date=createBookingDto.Date,
                PersonCount = createBookingDto.PersonCount,
            };
            _bookingService.AddAsync(booking);

            return Ok("Rezervasyon Başarı ile Yapıldı.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
           var value= _bookingService.GetByIdAsync(id);
           _bookingService.DeleteAsync(value);

            return Ok("Rezervasyon Başarı ile Silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto) 
        {
            Booking booking = new Booking() 
            {  
                BookingID = updateBookingDto.BookingID,
                Date=updateBookingDto.Date,
                Name = updateBookingDto.Name,
                PhoneNumber = updateBookingDto.PhoneNumber,
                Email = updateBookingDto.Email,
                PersonCount=updateBookingDto.PersonCount,
            };
            _bookingService.UpdateAsync(booking);

            return Ok("Rezervasyonunuz Başarı ile Güncellenmiştir.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value=_bookingService.GetByIdAsync(id);

            return Ok(value);
        }
    }
}
