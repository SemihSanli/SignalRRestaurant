using AutoMapper;
using SignalR.DTOLayer.ProductDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
                CreateMap<Product,ResultProductDTO>().ReverseMap();
                CreateMap<Product,CreateProductDTO>().ReverseMap();
                CreateMap<Product,UpdateProductDTO>().ReverseMap();
                CreateMap<Product,GetProductDTO>().ReverseMap();
                CreateMap<Product,ResultProductWithCategory>().ReverseMap();
        }
    }
}
