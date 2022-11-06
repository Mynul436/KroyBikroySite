using System;
using System.Collections.Generic;
using System.Linq;
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
    public class NewsController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsController(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<IActionResult> NewsFeed([FromQuery]core.Helpers.UserParams userParams)
        {
            var products = await _unitOfWork.ProductRepository.newsFeed(userParams);
            var newsFeeds = _mapper.Map<List<NewsFeedDto>>(products);
                        
           return Ok(new PagedResponse<List<NewsFeedDto>>(newsFeeds, products.CurrentPage, products.PageSize, products.TotalCount));
        }

    }
}