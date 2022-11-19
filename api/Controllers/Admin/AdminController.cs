using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
  //  [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [Route("Add-product-type")]
        public async Task<IActionResult> AddProductType(string productTypeName)
        {
            var type = new ProductType 
            {
                Name = productTypeName
            };
            _unitOfWork.TypeRepository.AddAsync(type);

            await _unitOfWork.CommitAsync();
            return Ok("New Product Type Added");
        } 
    }
}