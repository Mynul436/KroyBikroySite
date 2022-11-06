
using System.Linq.Expressions;
using api.Dto;
using api.Extensions;
using api.Helper;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Users
{
     [ApiController]
    [Route("[controller]")]
   
    public class RattingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
      
        private readonly IMapper _mapper;

        public RattingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Add-rating")]
         [Authorize]
        public async Task<IActionResult> AddRattingToProduct(ProductRatingDto ratingDto)
        {
            if(!await _unitOfWork.ProductRepository.isExitAsync(filter => filter.Id == ratingDto.ProductId))
                return BadRequest();
            var rating = _mapper.Map<ProductRatting>(ratingDto);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(User.GetUserId());
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(ratingDto.ProductId);

            user.Rattings = new List<ProductRatting>();
            product.Rattings = new List<ProductRatting>();

            user.Rattings.Add(rating);
            product.Rattings.Add(rating);

            await _unitOfWork.CommitAsync();

            return Ok(new Response<string>("Added Ratting"));
        }


        

        [HttpGet]
        public async Task<IActionResult> GetRattingOfProduct(int id)
        {

            List<Expression<Func<ProductRatting, object>>> includeExpression = new List<Expression<Func<ProductRatting, object>>>();
            
            includeExpression.Add(filter => filter.User);
            includeExpression.Add(filter => filter.Product);

            var rating = await _unitOfWork.ProductRating.FindAsync(filter => filter.ProductId == id, includeExpression);

            return Ok(rating);
        }
       
    }
}