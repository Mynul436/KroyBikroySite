using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dto;
using api.Extensions;
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
          [Route("my-product")]
        public async Task<IActionResult> MyProducts([FromQuery] core.Helpers.PaginationParams param)
        {

            var products = await _unitOfWork.ProductRepository.GetUserProducts(User.GetUserId(), param);
            var MyProducts = _mapper.Map< List<myAddProductViewDto>>(products);

            for(int i = 0; i < products.Count(); i++)
            {
                  try{
                        MyProducts[i].HighBidInfo = _mapper.Map<HighBidInfoDto>(products[i].Biddings.OrderByDescending(x => x.Price).FirstOrDefault());


                        if(await _unitOfWork.PaymentRequest.isExitAsync(filter => filter.CustomerId == MyProducts[i].HighBidInfo.UserId && filter.ProductId == MyProducts[i].Id))  {
                            MyProducts[i].HighBidInfo.requstInfo = true;
                        }
                  }
                  catch{

                  }
                    
            }
            

            return Ok(new PagedResponse<List<myAddProductViewDto>>(MyProducts, products.CurrentPage, products.PageSize, products.TotalCount));

        }


        [HttpPut]
        [Route("stop-bidding")]
        public async Task<IActionResult> StopBidding(int productId)
        {
            var product = await _unitOfWork.ProductRepository.FindOneAsync(filter => filter.OwnnerId == User.GetUserId() && filter.Id==productId);
            if(product == null) return BadRequest();

            product.BiddingStatus = false;
            _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpPut]
        [Route("on-bidding")]
        public async Task<IActionResult> OnBidding(int productId)
        {
            var product = await _unitOfWork.ProductRepository.FindOneAsync(filter => filter.OwnnerId == User.GetUserId() && filter.Id==productId);
            if(product == null) return BadRequest();

            product.BiddingStatus = true;
            _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
      
        [HttpPost]
        [Route("send-payment-request")]
        public async Task<IActionResult> SendPaymentRequest(AddPaymentReqestDto paymentReqest)
        {

            if(!await _unitOfWork.ProductRepository.isExitAsync(filter => filter.Id == paymentReqest.ProductId && filter.OwnnerId == User.GetUserId())   &&   !await _unitOfWork.ProductBidRepository.isExitAsync(filter => filter.ProductId == paymentReqest.ProductId && filter.UserId == paymentReqest.CustomerId)) return BadRequest();

          

            var product = await _unitOfWork.ProductRepository.FindOneAsync(filter => filter.Id == paymentReqest.ProductId);

            var user = await _unitOfWork.UserRepository.FindOneAsync(filter => filter.Id == paymentReqest.CustomerId);

            var paymentRequest = new PaymentRequest{
                Product = product,
                Customer = user
            };


            product.BiddingStatus = false;

            _unitOfWork.PaymentRequest.AddAsync(paymentRequest);
            _unitOfWork.ProductRepository.UpdateAsync(product);

            await _unitOfWork.CommitAsync();

            return Ok();
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
            var product = await _unitOfWork.ProductRepository
                .GetProductById(Id);

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