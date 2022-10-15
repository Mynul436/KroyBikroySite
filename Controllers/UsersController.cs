using AutoMapper;
using KroyBikroySite.Data;
using KroyBikroySite.Dto;
using KroyBikroySite.Interfaces;
using KroyBikroySite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KroyBikroySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository  userRepository,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<User>> GetUsers()
        {
        
            var users = mapper.Map<List<UserDto>>(await userRepository
                .GetUsers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
    
    }
}
