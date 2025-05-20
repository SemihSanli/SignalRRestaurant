using AutoMapper;
using SignalR.DTOLayer.TestimonialDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial,ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial,CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial,UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial,GetTestimonialDTO>().ReverseMap();
        }
    }
}
