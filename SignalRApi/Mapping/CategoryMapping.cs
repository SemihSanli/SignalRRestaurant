using AutoMapper;
using SignalR.DTOLayer.CategoryDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
                CreateMap<Category,ResultCategoryDTO>().ReverseMap();
                CreateMap<Category,CreateCategoryDTO>().ReverseMap();
                CreateMap<Category,GetCategoryDTO>().ReverseMap();
                CreateMap<Category,UpdateCategoryDTO>().ReverseMap();
        }
    }
}
