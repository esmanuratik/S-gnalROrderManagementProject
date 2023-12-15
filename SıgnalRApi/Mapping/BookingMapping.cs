using AutoMapper;
using DtoLayer.AboutDTO;
using DtoLayer.BookingDTO;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    public class BookingMapping:Profile
    {
        //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
        public BookingMapping()
        {
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();//ReverseMap Booking UpdateBookingDto ile UpdateBookingDto About ile eşleşebilir anlamına geliyor.
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
        }
    }
}
