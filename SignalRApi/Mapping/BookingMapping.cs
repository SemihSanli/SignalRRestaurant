using AutoMapper;
using SignalR.DTOLayer.BookingDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
                CreateMap<Booking,ResultBookingDTO>().ReverseMap();
                CreateMap<Booking,CreateBookingDTO>().ReverseMap();
                CreateMap<Booking,GetBookingDTO>().ReverseMap();
                CreateMap<Booking,UpdateBookingDTO>().ReverseMap();

        }
    }
}
