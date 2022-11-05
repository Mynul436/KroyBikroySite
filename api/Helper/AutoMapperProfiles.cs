

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
            CreateMap<Product, NewsFeedDto>()
                .ForMember( dest => dest.PictureURI, opt => opt.MapFrom( src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember( dest => dest.Type, opt => opt.MapFrom( src => src.Type.Name));

            CreateMap<ProductType, ProductTypeDto>();
        }
    }
}