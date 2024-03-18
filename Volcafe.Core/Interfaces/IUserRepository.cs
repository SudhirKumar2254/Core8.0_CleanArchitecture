using Volcafe.Core.Entities;

namespace Volcafe.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserDetails(string emailId);
    }
}
