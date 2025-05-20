using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.ContactDTO;
using SignalR.DTOLayer.DiscountDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDTO>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDTO createDiscountDTO)
        {
            _discountService.TAdd(new Discount()
            {
              DiscountAmount=createDiscountDTO.DiscountAmount,
              DiscountDescription=createDiscountDTO.DiscountDescription,
              DiscountImageURL=createDiscountDTO.DiscountImageURL,
              DiscountTitle=createDiscountDTO.DiscountTitle,
              DiscountStatus=false

            });
            return Ok("İndirim Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult DiscountList(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDTO updateDiscountDTO)
        {
            _discountService.TUpdate(new Discount()
            {
               DiscountID=updateDiscountDTO.DiscountID,
               DiscountAmount=updateDiscountDTO.DiscountAmount,
               DiscountDescription=updateDiscountDTO.DiscountDescription,
               DiscountTitle = updateDiscountDTO.DiscountTitle,
               DiscountImageURL = updateDiscountDTO.DiscountImageURL,
               DiscountStatus=false
            });
            return Ok("İndirim Bilgileri Güncellendi");
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Ürün İndirimi Aktif Edildi");
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Ürün İndirimi Pasif Edildi");
        }
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            
            return Ok(_discountService.TGetListByStatusTrue());
        }
    }
}
