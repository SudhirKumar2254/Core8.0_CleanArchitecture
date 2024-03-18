using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;

namespace Volcafe.Core.Application
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _userRepository.GetAllUsers();
            return allUsers;
        }

        public async Task<User> GetUserDetails(string emailId)
        {
            var userDetails = await _userRepository.GetUserDetails(emailId);
            return userDetails;
        }
    }
}
