using api.Dto;
using api.Extensions;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BidController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BidController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddBidToProduct(ProductBitDto productBitDto)
        {

            if(await _unitOfWork.ProductBidRepository.isExitAsync(filter => filter.UserId == User.GetUserId() && filter.ProductId == productBitDto.ProductId))
            {
                var _productBit = await _unitOfWork.ProductBidRepository.FindOneAsync(filter => filter.UserId == User.GetUserId()  && filter.ProductId == productBitDto.ProductId);
                _productBit.Price = productBitDto.Price;
                _unitOfWork.ProductBidRepository.UpdateAsync(_productBit);
                await _unitOfWork.CommitAsync();
                return Ok();
            }

            var productBit = _mapper.Map<ProductBid>(productBitDto);

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productBitDto.ProductId);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(User.GetUserId());

            product.Biddings = new List<ProductBid>();
            user.Biddings = new List<ProductBid>();

            
            product.Biddings.Add(productBit);
            user.Biddings.Add(productBit);

            
            await _unitOfWork.CommitAsync();
    
            return Ok();
        }
    }
}