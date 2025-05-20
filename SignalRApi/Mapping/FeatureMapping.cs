using AutoMapper;
using SignalR.DTOLayer.FeatureDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
                CreateMap<Feature,ResultFeatureDTO>().ReverseMap();
                CreateMap<Feature,CreateFeatureDTO>().ReverseMap();
                CreateMap<Feature,UpdateFeatureDTO>().ReverseMap();
                CreateMap<Feature,GetFeatureDTO>().ReverseMap();
        }
    }
}
