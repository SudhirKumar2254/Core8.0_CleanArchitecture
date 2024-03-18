using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Volcafe.Application.DTO;
using Volcafe.Core.Entities;
using Volcafe.Core.Interfaces;

namespace Volcafe.Services.Controllers
{
    [Route("[controller]")]
    [Route("/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [Route("/")]
        [HttpGet("HealthCheck")]
        public string HealthCheck()
        {
            return "Agent Portal - Web api is up and running at " + DateTime.Now;
        }
        [HttpGet("GetAllUsers")]
        public async Task<ObjectResult> GetAllUsers()
        {
            try
            {
                _logger.LogInformation("Inside GetAllUsers");
                var allUsers = await _userService.GetAllUsers();
                var userList = _mapper.Map<List<User>, List<UserDTO>>(allUsers);
                string response = JsonSerializer.Serialize(userList);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in GetAllUsers. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetUserDetails/{emailId}")]
        public async Task<ObjectResult> GetUserDetails(string emailId)
        {
            try
            {
                _logger.LogInformation("Inside GetUserDetails");
                var userDetails = await _userService.GetUserDetails(emailId);
                var userDetail = _mapper.Map<User, UserDTO>(userDetails);
                string response = JsonSerializer.Serialize(userDetail);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = $"Error in GetUserDetails. Message-{ex.Message}. StackTrace-{ex.StackTrace}";
                _logger.LogError(error);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
