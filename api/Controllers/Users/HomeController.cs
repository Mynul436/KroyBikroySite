using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dto;
using api.Helper;
using AutoMapper;
using core.Entities;
using core.Helpers;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Users
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Type-list")]
        public async Task<IActionResult> GetTypes()
        {
            var productTypes = await _unitOfWork.TypeRepository.GetAllAsync();

            return Ok(new Response<List<ProductTypeDto>>(_mapper.Map<List<ProductTypeDto>>(productTypes)));
        }


        [HttpGet]
        public async Task<IActionResult> NewsFeed([FromQuery] core.Helpers.UserParams userParams)
        {
            var products = await _unitOfWork.ProductRepository.newsFeed(userParams);
            var newsFeeds = _mapper.Map<List<NewsFeedDto>>(products);

            return Ok(new PagedResponse<List<NewsFeedDto>>(newsFeeds, products.CurrentPage, products.PageSize, products.TotalCount));
        }


        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var product = await _unitOfWork.ProductRepository.GetProductById(Id);

             var viewProduct = _mapper.Map<ProductViewDto>(product);


            // viewProduct.ProductOwnner = _mapper.Map<ProductOwnnerViewDto>(product.Ownner);

            // viewProduct.ProductBidding = _mapper.Map<List<ProductBiddingViewDto>>(product.Biddings);


            // List<Expression<Func<ProductRatting, object>>> includeExpression = new List<Expression<Func<ProductRatting, object>>>();

            // includeExpression.Add(filter => filter.User);
            // includeExpression.Add(filter => filter.Product);

            // viewProduct.ProductRatting = _mapper.Map<List<ProductRatingViewDto>>(await _unitOfWork.ProductRating.FindAsync(filter => filter.ProductId == Id, includeExpression));

            viewProduct.Photos = new List<string>();

            
            foreach (var photo in product.Photos)
            {
                viewProduct.Photos.Add(photo.Url);
            }

            return Ok(new Response<ProductViewDto>(viewProduct));
        }
    }
}