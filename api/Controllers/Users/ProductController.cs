using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Extensions;
using api.Helper;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Seller
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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



        [HttpPost]
        [Route("Add-rating")]
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


        private  async Task<byte[]> GetBytes(IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}