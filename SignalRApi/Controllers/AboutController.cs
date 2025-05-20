using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.AboutDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            About about = new About()
            {
                AboutTitle = createAboutDTO.AboutTitle,
                AboutDescription = createAboutDTO.AboutDescription,
                AboutImageURL = createAboutDTO.AboutImageURL,
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            About about = new About()
            {
                AboutID = updateAboutDTO.AboutID,
                AboutImageURL = updateAboutDTO.AboutImageURL,
                AboutDescription = updateAboutDTO.AboutDescription,
                AboutTitle = updateAboutDTO.AboutTitle,
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
           var value= _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
