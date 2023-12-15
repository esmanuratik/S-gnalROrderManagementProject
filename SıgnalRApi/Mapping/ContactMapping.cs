using AutoMapper;
using DtoLayer.CategoryDTO;
using DtoLayer.ContactDTO;
using EntityLayer.Entities;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Mapping
{
    //Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, UpdateContactDto>().ReverseMap();//ReverseMap Contact UpdateContactDto ile UpdatContactDto Contact ile eşleşebilir anlamına geliyor.
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
    }
}
