using api.Dto;
using api.Extensions;
using api.Helper;
using AutoMapper;
using core.Entities;
using core.Interfaces;
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

            return Ok(new Response<List<ProductTypeDto>>(_mapper.Map<List<ProductTypeDto>>(productTypes)));
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

            _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
            
            return Ok(new Response<string>("Added new Product"));
        }


        [HttpDelete]
        [Route("Delete/{Id}")]
        
        public async Task<IActionResult> DeleteProducts([FromRoute]int Id)
        {
            if(!await _unitOfWork.ProductBidRepository.isExitAsync(filter => filter.Id == Id))
                return BadRequest(new Response<string>("Not Exits"));

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