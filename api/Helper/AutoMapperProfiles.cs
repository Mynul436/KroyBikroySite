

using api.Dto;
using AutoMapper;
using core.Entities;

namespace api.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Signup, User>();

            CreateMap<User, MemberDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}