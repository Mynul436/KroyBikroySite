using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using AutoMapper;
using core.Interfaces;
using infrastructure.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Users
{

     [ApiController]
    [Route("[controller]")]
    public class ProfileController :  ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfileController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //[HttpGet]
        //[Route("Profile")]

        //public async Task<IActionResult> Getuser()
        //{
        //    var user = await _unitOfWork.UserRepository.FindOneAsync(filter => filter.Id == User.GetUserId());
        //return Ok(user);
        
        //}


    }
}