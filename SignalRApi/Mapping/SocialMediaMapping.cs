using AutoMapper;
using SignalR.DTOLayer.SocialMediaDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDTO>().ReverseMap();
        }
    }
}
