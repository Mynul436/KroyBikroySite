
using core.Entities;
using core.Helpers;
using infrastructure.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly UnitOfWork _unitOfWork;
        public UserController(UnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }




       
        
    }
}