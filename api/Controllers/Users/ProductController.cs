using System.Linq.Expressions;
using api.Dto;
using api.Extensions;

using AutoMapper;
using core.Entities;
using core.Helpers;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Seller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }

        [HttpGet]
         [Route("Type-list")]
        public async Task<IActionResult> GetTypes()
        {
            var productTypes = await _unitOfWork.TypeRepository.GetAllAsync();

            return Ok(new Helper.Response<List<ProductTypeDto>>(_mapper.Map<List<ProductTypeDto>>(productTypes)));
        }



        // [Authorize]
        [HttpGet]
        [Route("product-bidding-info")]
        public async Task<IActionResult> ProductBidding([FromQuery]PaginationParams filter)
        {
            var products = await _unitOfWork.ProductRepository.GetBiddingProduct(16, filter);

            foreach(var product in products){

                List<Expression<Func<ProductBid, object>>> includeExpression = new List<Expression<Func<ProductBid, object>>>();

                includeExpression.Add(filter => filter.User);

                var bidUser = await _unitOfWork.ProductBidRepository.FindAsync(filter => filter.ProductId == product.Id, includeExpression);
                product.Biddings.Concat(bidUser);
            }

            var productLists = new List<ProductBiddingView>();

            foreach(var product in products){    
                productLists.Add(_mapper.Map<ProductBiddingView>(product));
            }

            return Ok(new Helper.PagedResponse<List<ProductBiddingView>>(productLists, products.CurrentPage, products.PageSize, products.TotalCount));
        }
        


        [HttpPost]
        [Route("Add-product")]
        public async Task<IActionResult> AddProduct([FromForm]ProductDto productDto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var product = _mapper.Map<Product>(productDto);
            product.Ownner = await _unitOfWork.UserRepository.GetByIdAsync(User.GetUserId());
            product.Type = await _unitOfWork.TypeRepository.GetByIdAsync(productDto.TypeId);

            var productPhoto = new List<Photo>();

            foreach(var file in productDto.Pictures)
            {
                var cloud = await _photoService.AddPhotoAsync(file);
                var photo = new Photo
                {
                    Url = cloud.SecureUri.AbsoluteUri,
                    PublicId = cloud.PublicId
                };
                productPhoto.Add(photo);
            }

            productPhoto[0].IsMain = true;
            product.Photos = productPhoto;

            product.Quantity = 1;

            _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
            
            return Ok(new Helper.Response<string>("Added new Product"));
        }


        [HttpDelete]
        [Route("Delete/{Id}")]
        
        public async Task<IActionResult> DeleteProducts([FromRoute]int Id)
        {
            if(!await _unitOfWork.ProductBidRepository.isExitAsync(filter => filter.Id == Id))
                return BadRequest(new Helper.Response<string>("Not Exits"));

            var product = await _unitOfWork.ProductRepository.FindOneAsync(filter => filter.Id == Id);
            _unitOfWork.ProductRepository.RemoveAsync(product);

            await _unitOfWork.CommitAsync();
            return Ok("Ok");
        }


        private  async Task<byte[]> GetBytes(IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}