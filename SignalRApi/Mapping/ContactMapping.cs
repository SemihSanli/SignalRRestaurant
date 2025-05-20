using AutoMapper;
using SignalR.DTOLayer.ContactDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
                CreateMap<Contact,ResultContactDTO>().ReverseMap();
                CreateMap<Contact,CreateContactDTO>().ReverseMap();
                CreateMap<Contact,GetContactDTO>().ReverseMap();
                CreateMap<Contact,UpdateContactDTO>().ReverseMap();
        }
    }
}
