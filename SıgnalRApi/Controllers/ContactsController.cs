using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDTO;
using DtoLayer.ContactDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.AddAsync(new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                MailAddress = createContactDto.MailAddress,
                PhoneNumber = createContactDto.PhoneNumber,
                FooterTitle = createContactDto.FooterTitle,
                OpenDays = createContactDto.OpenDays,
                OpenDaysDescription = createContactDto.OpenDaysDescription,
                OpenHours = createContactDto.OpenHours,
            });
            return Ok("İletişim Bilgileri Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.GetByIdAsync(id);
            _contactService.DeleteAsync(value);

            return Ok("İletişim Bilgileri Başarıyla Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.UpdateAsync(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                MailAddress = updateContactDto.MailAddress,
                PhoneNumber = updateContactDto.PhoneNumber,
                FooterTitle= updateContactDto.FooterTitle,
                OpenDays = updateContactDto.OpenDays,
                OpenHours= updateContactDto.OpenHours,
                OpenDaysDescription = updateContactDto.OpenDaysDescription

            });

            return Ok("İletişim Bilgileri Başarıyla Güncellendi");
        }
    }
}

