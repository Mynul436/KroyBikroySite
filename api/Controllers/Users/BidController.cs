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
            var productBit = _mapper.Map<ProductBid>(productBitDto);

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productBitDto.ProductId);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(User.GetUserId());

            product.Biddings = new List<ProductBid>();
            user.Biddings = new List<ProductBid>();

            product.Biddings.Add(productBit);
            user.Biddings.Add(productBit);
            
            await _unitOfWork.CommitAsync();
    
            return Ok(productBit);
        }
    }
}