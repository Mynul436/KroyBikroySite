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
            Console.WriteLine(signup.Name);   
            if(!ModelState.IsValid) return BadRequest();
            if(await _unitOfWork.UserRepository.isExitAsync(filter => filter.Email == signup.Email)) 
                return BadRequest(new Response<string>("Email Already Exit"));
            if(await _unitOfWork.UserRepository.isExitAsync(filter => filter.UserName == signup.UserName)) return BadRequest(new Response<string>("Already Exit username"));

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
    

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login login)
        {
            if(!ModelState.IsValid){
                return BadRequest(new Response<String>("Wrong Formate"));
            }
            if(!await _unitOfWork.UserRepository.isExitAsync(filter => filter.Email == login.Email)) 
                return BadRequest();

            var user = await _unitOfWork.UserRepository.FindOneAsync(filter => filter.Email == login.Email);
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for(int i = 0; i < computedHash.Length; i++){
                if(computedHash[i] != user.PasswordHash[i]){
                    return BadRequest(new Response<String>("Wrong Password"));
                }
            }

            var res = _mapper.Map<MemberDto>(user);
            res.Token = _tokenService.CreateToken(user).Item1;
            return Ok(new Response<MemberDto>(res));

        }

    
    }
}