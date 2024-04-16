using AutoMapper;
using DtoLayer.MessageDTO;
using EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	//Profile AutoMapperdan geliyor ve bunun metotları sadece ctor içinde çağırılır ayrıca map lemek istediğim sınıfları metotları burada belirtiyorum ki sonradan tekrar tekrar tanımlamak zorunda kalmayayım.
	public class MessageMapping : Profile
	{
		public MessageMapping()
		{
			CreateMap<Message, UpdateMessageDto>().ReverseMap();//ReverseMap About UpdateAboutDto ile UpdateAboutDto About ile eşleşebilir anlamına geliyor.
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, ResultMessageDto>().ReverseMap();
		}
	}
}
