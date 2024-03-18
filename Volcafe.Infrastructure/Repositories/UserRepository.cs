using Microsoft.EntityFrameworkCore;
using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;
using Volcafe.Infrastructure.Data;

namespace Volcafe.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _databaseContext.Users.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUserDetails(string emailId)
        {
            var userDetails = _databaseContext.Users.Where(x => x.Email == emailId && x.Active == true).Include(x => x.UserRole).Include(x => x.UserType).FirstOrDefault();
            return userDetails ?? new User();
        }
    }
}
