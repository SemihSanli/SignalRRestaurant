using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.ProductDTO;
using SignalR.DTOLayer.TestimonialDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDTO>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialComment = createTestimonialDTO.TestimonialComment,
                TestimonialImageURL = createTestimonialDTO.TestimonialImageURL,
                TestimonialName = createTestimonialDTO.TestimonialName,
                TestimonialStatus = createTestimonialDTO.TestimonialStatus,
                TestimonialTitle = createTestimonialDTO.TestimonialTitle,

            });
            return Ok("Müşteri Yorum Bilgileri Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgileri Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult TestimonialList(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            _testimonialService.TUpdate(new Testimonial()
            {

                 TestimonialID = updateTestimonialDTO.TestimonialID,
                TestimonialComment = updateTestimonialDTO.TestimonialComment,
                TestimonialImageURL = updateTestimonialDTO.TestimonialImageURL,
                TestimonialName = updateTestimonialDTO.TestimonialName,
                TestimonialStatus = updateTestimonialDTO.TestimonialStatus,
                TestimonialTitle = updateTestimonialDTO.TestimonialTitle,
            });
            return Ok("Müşteri Yorum Bilgileri Güncellendi");
        }
    }
}
