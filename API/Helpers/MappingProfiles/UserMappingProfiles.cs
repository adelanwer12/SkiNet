using API.Dtos;
using AutoMapper;
using Core.Entities.Identity;

namespace API.Helpers.MappingProfiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}