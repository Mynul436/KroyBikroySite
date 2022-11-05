using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
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
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductDto productDto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var product = _mapper.Map<Product>(productDto);
            product.Ownner = await _unitOfWork.UserRepository.GetByIdAsync(productDto.OwnnerId);
            product.Type = await _unitOfWork.TypeRepository.GetByIdAsync(productDto.TypeId);

            var productPhoto = new List<Picture>();
        
            foreach(var photo in productDto.Pictures)
            {
                var _photo = new Picture();
                _photo.photo = await this.GetBytes(photo);
                productPhoto.Add(_photo);
            }

            product.Photos = productPhoto;

            _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return Ok(product);
        }

        private  async Task<byte[]> GetBytes(IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}