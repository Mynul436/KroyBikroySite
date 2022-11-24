using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Extensions;
using api.Helper;
using AutoMapper;
using core.Helpers;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Users
{
     [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> MyCard([FromQuery] core.Helpers.PaginationParams param)
        {
            var carts = await _unitOfWork.ProductRepository.userProductCart(User.GetUserId(), param);
            
            var productCartView =  _mapper.Map<List<ProductCartViewDto>>(carts);

           return Ok(new PagedResponse<List<ProductCartViewDto>>(productCartView, carts.CurrentPage, carts.PageSize, carts.TotalCount));
        }


        [HttpGet]
        [Route("product-payment")]
        public async Task<IActionResult> ProductPayment()
        {
            var payments = await _unitOfWork.PaymentRequest.FindAsync(filter => filter.CustomerId == User.GetUserId());
            
            var products = new List<ViewProductPaymentDto>();

            foreach(var payment in payments){
                var product = new ViewProductPaymentDto{
                    Id = payment.ProductId,
                    Price = payment.Prices,
                };

                var _p = await _unitOfWork.ProductRepository.FindOneAsync(filter => filter.Id == payment.ProductId);

                var _u = await _unitOfWork.UserRepository.FindOneAsync(filter => filter.Id == _p.OwnnerId);

                product.Ownner = new ProductOwnnerViewDto();
                product.ProductName = _p.Name;
                product.Ownner.Name = _u.Name;
                product.Ownner.Email = _u.Email;
                product.Ownner.Phone = _u.Phone;
                product.Ownner.Id = _u.Id;
                products.Add(product);
            
            }
            return Ok(products);
        }

        
        [HttpPost]
        [Route("payment")]
        public async Task<IActionResult> Payment(AddPaymentDto paymentDto)
        {
            
            return Ok();
        }

      


    }
}