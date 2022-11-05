using System.Security.Cryptography;
using System.Text;
using api.Dto;
using api.Helper;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IRepository<User> userRepository){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }   


        [HttpPost]
        public async Task<IActionResult> Register(Signup signup)
        {
            if(!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<User>(signup);
            
            using var hmac = new HMACSHA512();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signup.Password));
            user.PasswordSalt = hmac.Key;
        
            _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            var res = _mapper.Map<MemberDto>(user);
            res.Token = _tokenService.CreateToken(user).Item1;

            return Ok(new Response<MemberDto>(res));
        }
    }
}