using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.DiscountDTO;
using SignalR.DTOLayer.FeatureDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDTO>>(_featureService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            _featureService.TAdd(new Feature()
            {
                FeatureDescription1 = createFeatureDTO.FeatureDescription1,
                FeatureDescription2 = createFeatureDTO.FeatureDescription2,
                FeatureDescription3 = createFeatureDTO.FeatureDescription3,
                FeatureTitle1 = createFeatureDTO.FeatureTitle1,
                FeatureTitle2 = createFeatureDTO.FeatureTitle2,
                FeatureTitle3 = createFeatureDTO.FeatureTitle3,

            });
            return Ok("Öne Çıkanlar Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Öne Çıkanlar Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult FeatureList(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            _featureService.TUpdate(new Feature()
            {

                FeatureID = updateFeatureDTO.FeatureID,
                FeatureDescription1 = updateFeatureDTO.FeatureDescription1,
                FeatureDescription2 = updateFeatureDTO.FeatureDescription2,
                FeatureDescription3 = updateFeatureDTO.FeatureDescription3,
                FeatureTitle1 = updateFeatureDTO.FeatureTitle1,
                FeatureTitle2 = updateFeatureDTO.FeatureTitle2,
                FeatureTitle3 = updateFeatureDTO.FeatureTitle3,
            });
            return Ok("Öne Çıkanların Bilgileri Güncellendi");
        }
    }
}
