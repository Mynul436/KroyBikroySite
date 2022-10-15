using KroyBikroySite.Model;

namespace KroyBikroySite.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(Guid Id);

        Task<User> GetUserByName(string UserName);

        Task<User> GetUserByEmail(string Email);
        
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        void DeleteUser(Guid Id);


    }
}
