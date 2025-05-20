using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.ContactDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDTO>>(_contactService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            _contactService.TAdd(new Contact()
            {
              ContactFooterDescription = createContactDTO.ContactFooterDescription,
              ContactEmail = createContactDTO.ContactEmail,
              ContactLocation = createContactDTO.ContactLocation,
              ContactPhone = createContactDTO.ContactPhone,

            });
            return Ok("İletişim Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgileri Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult ContactList(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDTO.ContactID,
                ContactFooterDescription = updateContactDTO.ContactFooterDescription,
                ContactLocation = updateContactDTO.ContactLocation,
                ContactEmail = updateContactDTO.ContactEmail,
                ContactPhone = updateContactDTO.ContactPhone,

            });
            return Ok("İletişim Bilgileri Güncellendi");
        }

    }
}
