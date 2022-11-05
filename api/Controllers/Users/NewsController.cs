using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using AutoMapper;
using core.Entities;
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
        public async Task<IActionResult> NewsFeed()
        {
            var products = await _unitOfWork.ProductRepository.newsFeed();

            var newsFeeds = _mapper.Map<List<NewsFeedDto>>(products);

            // foreach(var feed in newsFeeds)
            // {
            //     var picture = await _unitOfWork.ProductPictureRepository.FindOneAsync(filter => filter.ProductId == feed.Id);
            //     feed.ProductPhoto = picture != null ?  picture.photo : null;
            // }

            return Ok(newsFeeds);
        }

    }
}