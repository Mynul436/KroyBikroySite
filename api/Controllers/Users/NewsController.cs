using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using core.Interfaces;
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
            return Ok(products);
        }

    }
}