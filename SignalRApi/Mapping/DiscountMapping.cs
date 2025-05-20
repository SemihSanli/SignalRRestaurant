using AutoMapper;
using SignalR.DTOLayer.DiscountDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
                CreateMap<Discount,ResultDiscountDTO>().ReverseMap();
                CreateMap<Discount,UpdateDiscountDTO>().ReverseMap();
                CreateMap<Discount,CreateDiscountDTO>().ReverseMap();
                CreateMap<Discount,GetDiscountDTO>().ReverseMap();
        }
    }
}
