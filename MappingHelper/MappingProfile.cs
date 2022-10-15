using AutoMapper;
using KroyBikroySite.Dto;
using KroyBikroySite.Model;

namespace KroyBikroySite.MappingHelper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();


        }
    }
}
