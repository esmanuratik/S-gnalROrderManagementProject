using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DtoLayer.MessageDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessagesController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var value = _mapper.Map<List<ResultMessageDto>>(_messageService.GetListAllAsync());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			_messageService.AddAsync(new Message()
			{
				Mail = createMessageDto.Mail,
				Subject = createMessageDto.Subject,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate = createMessageDto.MessageSendDate,
				NameSurname = createMessageDto.NameSurname,
				PhoneNumber = createMessageDto.PhoneNumber,	
				Status = false,
			});
			return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.GetByIdAsync(id);
			_messageService.DeleteAsync(value);

			return Ok("Mesaj başarıyla silindi.");

		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.GetByIdAsync(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			_messageService.UpdateAsync(new Message()
			{
				Mail= updateMessageDto.Mail,
				Subject = updateMessageDto.Subject,
				MessageContent = updateMessageDto.MessageContent,
				Status = false,
				PhoneNumber= updateMessageDto.PhoneNumber,
				NameSurname = updateMessageDto.NameSurname,
				MessageSendDate= updateMessageDto.MessageSendDate,
				MessageID = updateMessageDto.MessageID							
			});

			return Ok("Mesaj başarıyla güncellendi");
		}

	}
}
