using KroyBikroySite.Data;
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
        private readonly UserDbContext _dbContext;

        public UsersController(UserDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUser)
        {
            var user = new User()
            {
                UserId = Guid.NewGuid(),
                FirstName = addUser.FirstName,
                LastName = addUser.LastName,
                Email = addUser.Email,
                
                PhoneNumber = addUser.PhoneNumber,
                Address = addUser.Address,
            };
            await _dbContext.Users.AddAsync(user);

           await _dbContext.SaveChangesAsync();

            return Ok(user);

        }
    }
}
