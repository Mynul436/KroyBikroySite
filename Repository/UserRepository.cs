using KroyBikroySite.Data;
using KroyBikroySite.Dto;
using KroyBikroySite.Interfaces;
using KroyBikroySite.Model;
using Microsoft.EntityFrameworkCore;

namespace KroyBikroySite.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }
        public async Task<User> AddUser(User user)
        {
            var result =await userDbContext.Users.AddAsync(user);
            await userDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteUser(Guid Id)
        {
            var result = await userDbContext.Users.Where(u=>u.UserId==Id)
                .FirstOrDefaultAsync();

            if (result != null)
            {
                userDbContext.Users.Remove(result);
                await userDbContext.SaveChangesAsync();
            }
            
        }

        public void DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(Guid Id)
        {
            return await userDbContext.Users.Where(u => u.UserId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUserByName(string UserName)
        {
            return await userDbContext.Users.ToListAsync();
        }

        public Task<User> GetUserByUsername(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(User user)
        {
           var result= await userDbContext.Users
                .FirstOrDefaultAsync(u=>u.UserId==user.UserId);
            await userDbContext.SaveChangesAsync();

            if(result!=null)
            {
                 result.FirstName=user.FirstName;
                 result.LastName=user.LastName;
                 result.Email=user.Email;
                 result.PhoneNumber=user.PhoneNumber;
                 result.Address=user.Address;
                 return result;
            }
            return null;
        }

        Task<User> IUserRepository.GetUserByName(string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
