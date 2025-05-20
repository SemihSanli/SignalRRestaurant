using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.BookingDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IValidator<CreateBookingDTO> _validator;

        public BookingController(IBookingService bookingService, IValidator<CreateBookingDTO> validator)
        {
            _bookingService = bookingService;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO createBookingDTO)
        {
            var validationResult = _validator.Validate(createBookingDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            Booking booking = new Booking()
            {
                BookingMail = createBookingDTO.BookingMail,
                BookingDate = createBookingDTO.BookingDate,
                BookingPersonCount = createBookingDTO.BookingPersonCount,
                BookingName = createBookingDTO.BookingName,
                BookingPhone = createBookingDTO.BookingPhone,
                BookingDescription = createBookingDTO.BookingDescription,
            };
            _bookingService.TAdd(booking);

            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
           
           var value= _bookingService.TGetByID(id);
          _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDTO.BookingID,
                BookingMail = updateBookingDTO.BookingMail,
                BookingDate = updateBookingDTO.BookingDate,
                BookingPersonCount = updateBookingDTO.BookingPersonCount,
                BookingName = updateBookingDTO.BookingName,
                BookingPhone = updateBookingDTO.BookingPhone,
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value=_bookingService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.BookingStatusCancelled(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }
    }
}
