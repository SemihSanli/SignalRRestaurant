using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.SocialMediaDTO;
using SignalR.DTOLayer.TestimonialDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialmediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialmediaService, IMapper mapper)
        {
            _socialmediaService = socialmediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDTO>>(_socialmediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO)
        {
            _socialmediaService.TAdd(new SocialMedia()
            {
                SocialMediaIcon = createSocialMediaDTO.SocialMediaIcon,
                SocialMediaTitle = createSocialMediaDTO.SocialMediaTitle,
                SocialMediaURL = createSocialMediaDTO.SocialMediaURL,

            });
            return Ok("Sosyal Medya Bilgileri Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialmediaService.TGetByID(id);
            _socialmediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgileri Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult SocialMediaList(int id)
        {
            var value = _socialmediaService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            _socialmediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDTO.SocialMediaID,
                SocialMediaIcon = updateSocialMediaDTO.SocialMediaIcon,
                SocialMediaTitle = updateSocialMediaDTO.SocialMediaTitle,
                SocialMediaURL = updateSocialMediaDTO.SocialMediaURL,
            });
            return Ok("Sosyal Medya Bilgileri Güncellendi");
        }
    }
}
