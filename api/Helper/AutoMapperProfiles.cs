

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



            CreateMap<Product, ProductViewDto>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Type));

            CreateMap<User, ProductOwnnerViewDto>();

            CreateMap<ProductBitDto, ProductBid>();


            CreateMap<ProductBid, ProductBiddingViewDto>()
                .ForMember( dest => dest.Name, opt => opt.MapFrom(src => src.User.Name));

            
            CreateMap<ProductRatingDto, ProductRatting>();

            CreateMap<ProductRatting, ProductRatingViewDto>()
                .ForMember( dest => dest.Name, opt => opt.MapFrom( src => src.User.Name));


            CreateMap<ProductType, ProductTypeViewDto>();

            CreateMap<Product, ProductBiddingView>()
                .ForMember( dest => dest.BiddingPrices, opt => opt.MapFrom( src => src.Biddings.OrderByDescending(x => x.Price).FirstOrDefault().Price))
                .ForMember( dest => dest.CustomerId, opt => opt.MapFrom(src => src.Biddings.OrderByDescending(user => user.UserId).FirstOrDefault().UserId))

                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Biddings.OrderByDescending(x => x.Price).FirstOrDefault().User.Name));
        }
    }
}